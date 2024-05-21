using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class GameCharacter : GameObject
{
    public float Speed { get; private set; }
    private float deltaSpeed => Speed / 100;

    private Coordinate toLocation;
    public Coordinate MoveDirection { get; private set; }
    public bool IsMoving { get; private set; }


    private bool isMovingByPath;
    private int indexPointPath = 0;
    private List<Coordinate> movePath;
    private Action endPathCallback;

    public GameCharacter(Coordinate location, float rotation, float speed = 0.0f) : base(location, rotation)
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

    public void MoveTo(Coordinate toLocation)
    {
        this.toLocation = toLocation;
        MoveDirection = toLocation - Location;
        IsMoving = true;
    }

    public void MoveTo(float toX, float toY)
    {
        toLocation = new Coordinate(toX, toY);
        MoveDirection = toLocation - Location;
        IsMoving = true;
    }

    public void MoveByPath(List<Coordinate> path, Action callback)
    {
        movePath = path;
        endPathCallback = callback;
        indexPointPath = 0;
        isMovingByPath = true;
    }

    public void MoveUpdate(double dt)
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

        SetLocation(Location + MoveDirection.Normalized() * deltaSpeed * dt);
        if (Location.IsInRadius(toLocation, Settings.CoordInaccuracy))
            IsMoving = false;
    }
}
