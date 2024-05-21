class GameObject
{
    public Coordinate Location { get; private set; }
    public float Rotation { get; private set; }

    public GameObject(Coordinate location, float rotation = 0.0f)
    {
        Location = location;
        Rotation = rotation;
    }

    public GameObject(float x = 0.0f, float y = 0.0f, float rotation = 0.0f)
    {
        Location = new Coordinate(x, y);
        Rotation = rotation;
    }

    public void SetLocation(Coordinate coord)
    {
        Location = coord;
    }

    public void SetLocation(int x, int y)
    {
        Location = new Coordinate(x, y);
    }

    public void SetRotation(float rotation)
    {
        Rotation = rotation;
    }
}
