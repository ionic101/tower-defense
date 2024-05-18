using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

class TowersViewer
{
    private SpriteBatch _spriteBatch;
    private Dictionary<TowerType, Texture2D> _towerTextures;

    private GameSessionData sessionData;

    public TowersViewer(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        _spriteBatch = spriteBatch;
        this.sessionData = sessionData;
    }

    public void LoadTextures(Dictionary<TowerType, Texture2D> towerTextures)
    {
        _towerTextures = towerTextures;
    }

    public void Display()
    {
        foreach (var tower in sessionData.TowerList)
        {
            _spriteBatch.Draw(_towerTextures[tower.Type],
                    new Rectangle(tower.Coord.X * Settings.CellSize, tower.Coord.Y * Settings.CellSize, Settings.CellSize, Settings.CellSize),
                    color: Color.White);
        }
    }
}
