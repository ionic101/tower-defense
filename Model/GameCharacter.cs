using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class GameCharacter : GameObject
{
    public float Speed { get; private set; }
    private float deltaSpeed => Speed / 100;

    private Vector2 toLocation;
    public Vector2 MoveDirection { get; private set; }
    public bool IsMoving { get; private set; }


    private bool isMovingByPath;
    private int indexPointPath = 0;
    private List<Vector2> movePath;
    private Action endPathCallback;

    public GameCharacter(Vector2 location, float rotation, float speed = 0.0f) : base(location, rotation)
    {
        Speed = speed;
    }
    public GameCharacter(float x, float y, float rotation, float speed = 0.0f) : base(x, y, rotation)
    {
        Speed = speed;
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    public void MoveTo(Vector2 toLocation)
    {
        this.toLocation = toLocation;
        MoveDirection = Vector2.Normalize(toLocation - Location);
        IsMoving = true;
    }

    public void MoveTo(float toX, float toY)
    {
        toLocation = new Vector2(toX, toY);
        MoveDirection = Vector2.Normalize(toLocation - Location);
        IsMoving = true;
    }

    public void MoveByPath(List<Vector2> path, Action callback)
    {
        movePath = path;
        endPathCallback = callback;
        indexPointPath = 0;
        isMovingByPath = true;
    }

    static bool IsInRadius(Vector2 firstVector, Vector2 secondVector, float radius)
    {
        return Vector2.Distance(firstVector, secondVector) <= radius;
    }

    private bool isMoveDirectionCorrect()
    {
        var newDirection = Location - toLocation;
        newDirection.Normalize();

        return newDirection.Equals(MoveDirection);
    }

    public void MoveUpdate(float dt)
    {
        if (!IsMoving && isMovingByPath)
        {
            if (indexPointPath >= movePath.Count())
            {
                endPathCallback.Invoke();
                isMovingByPath = false;
                return;
            }

            MoveTo(movePath[indexPointPath]);

            indexPointPath++;
        }

        if (!IsMoving)
            return;

        SetLocation(Location + MoveDirection * deltaSpeed * dt);
        if (IsInRadius(Location, toLocation, Settings.CoordInaccuracy) || isMoveDirectionCorrect())
            IsMoving = false;
    }

    public void RotationUpdate()
    {
        var sign = Math.Abs(MoveDirection.Y) < Settings.CoordInaccuracy ? 1 : Math.Sign(MoveDirection.Y);
        
        var newRotation = (float)Math.Acos(MoveDirection.X) * sign;

        SetRotation(newRotation);
    }
}
