using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

class MapViewer
{
    private SpriteBatch _spriteBatch;
    private Dictionary<CellType, Texture2D> _textures;
    private GameSessionData sessionData;

    public MapViewer(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        _spriteBatch = spriteBatch;
        this.sessionData = sessionData;
    }

    public void LoadTextures(Dictionary<CellType, Texture2D> textures)
    {
        _textures = textures;
    }

    public void Display()
    {
        for (int x = 0; x < sessionData.GameMap.MapWidth; x++)
        {
            for (int y = 0; y < sessionData.GameMap.MapHeight; y++)
            {
                _spriteBatch.Draw(texture: _textures[sessionData.GameMap.Cells[x, y].Type],
                    new Rectangle(x * Settings.CellSize, y * Settings.CellSize, Settings.CellSize, Settings.CellSize),
                    color: Color.White);
            }
        }

    }
}
