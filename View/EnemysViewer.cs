using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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

    //TO REFACT!!!!!
    public void Display()
    {
            foreach (var enemy in sessionData.EnemyList)
            {
                spriteBatch.Draw(enemyTextures[enemy.Type],
                    enemy.Location * Settings.CellSize + new Vector2(Settings.CellSize / 2.0f, Settings.CellSize / 2.0f),
                    null,
                    Color.White,
                    enemy.Rotation,
                    new Vector2(64, 64),
                    Settings.CellSize / 128.0f,
                    SpriteEffects.None,
                    0f);
            }
    }
}
