using Microsoft.Xna.Framework;

enum TowerType
{
    Policeman,
    Soldar,
    Minigunner
}

class Tower
{
    public TowerType Type;
    public Coords Coord;

    public Tower(TowerType type, Coords coord)
    {
        Type = type;
        Coord = coord;
    }
}
