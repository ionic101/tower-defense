using Microsoft.Xna.Framework;

class GameObject
{
    public Vector2 Location { get; private set; }
    public float Rotation { get; private set; }

    public GameObject(Vector2 location, float rotation = 0.0f)
    {
        Location = location;
        Rotation = rotation;
    }

    public GameObject(float x = 0.0f, float y = 0.0f, float rotation = 0.0f)
    {
        Location = new Vector2(x, y);
        Rotation = rotation;
    }

    public void SetLocation(Vector2 coord)
    {
        Location = coord;
    }

    public void SetLocation(int x, int y)
    {
        Location = new Vector2(x, y);
    }

    public void SetRotation(float rotation)
    {
        Rotation = rotation;
    }
}
