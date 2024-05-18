using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

class EnemysViewer
{
    private SpriteBatch spriteBatch;
    private Dictionary<EnemyType, Texture2D> enemyTextures;

    private GameSessionData sessionData;

    public EnemysViewer(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        this.spriteBatch = spriteBatch;
        this.sessionData = sessionData;
    }

    public void LoadTextures(Dictionary<EnemyType, Texture2D> enemyTextures)
    {
        this.enemyTextures = enemyTextures;
    }

    public void Display()
    {
        foreach (var enemy in sessionData.EnemyList)
        {
            spriteBatch.Draw(enemyTextures[enemy.Type],
                    new Rectangle((int)(enemy.Coords.X * Settings.CellSize), (int)(enemy.Coords.Y * Settings.CellSize), Settings.CellSize, Settings.CellSize),
                    color: Color.White);
        }
    }
}
