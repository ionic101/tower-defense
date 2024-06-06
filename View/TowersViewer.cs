using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

class TowersViewer
{
    private SpriteBatch spriteBatch;
    private Dictionary<TowerType, Texture2D> towerTextures;

    private GameSessionData sessionData;

    public TowersViewer(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        this.spriteBatch = spriteBatch;
        this.sessionData = sessionData;
    }

    public void LoadTextures(Dictionary<TowerType, Texture2D> towerTextures)
    {
        this.towerTextures = towerTextures;
    }

    public void Display()
    {
        foreach (var tower in sessionData.TowerList)
        {
            spriteBatch.Draw(towerTextures[tower.Type],
                tower.Location * Settings.CellSize + new Vector2(Settings.CellSize / 2.0f, Settings.CellSize / 2.0f),
                null,
                Color.White,
                tower.Rotation,
                new Vector2(64, 64),
                Settings.CellSize / 128.0f,
                SpriteEffects.None,
                0f);
        }
    }
}
