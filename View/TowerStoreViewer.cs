using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

class TowerStoreViewer
{
    private SpriteBatch spriteBatch;
    private SpriteFont font;
    private GameSessionData sessionData;

    private Dictionary<TowerType, Texture2D> towerTextures;
    private Texture2D slotTexture;
    private Texture2D selectedTexture;

    public TowerStoreViewer(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        this.spriteBatch = spriteBatch;
        this.sessionData = sessionData;

        FindTowerButtonsLocations();
    }

    private void FindTowerButtonsLocations()
    {
        var lastX = sessionData.GameMap.MapWidth + 1;
        var lastY = 1;

        for (int towerIndex = 0; towerIndex < Enum.GetNames(typeof(TowerType)).Length; towerIndex++)
        {
            sessionData.towerButtonsLocations[new Vector2(lastX, lastY)] = (TowerType)towerIndex;
            lastY += 2;
        }
    }

    public void LoadTextures(Dictionary<TowerType, Texture2D> towerTextures, Texture2D slotTexture, SpriteFont font, Texture2D selectedTexture)
    {
        this.towerTextures = towerTextures;
        this.slotTexture = slotTexture;
        this.font = font;
        this.selectedTexture = selectedTexture;
    }

    public void Display()
    {
        foreach (var button in sessionData.towerButtonsLocations)
        {
            var buttonLocation = button.Key;
            var towerType = button.Value;

            spriteBatch.Draw(slotTexture, new Rectangle((int)buttonLocation.X * Settings.CellSize, (int)buttonLocation.Y * Settings.CellSize, Settings.CellSize, Settings.CellSize), Color.White);
            spriteBatch.Draw(towerTextures[towerType], new Rectangle((int)buttonLocation.X * Settings.CellSize, (int)buttonLocation.Y * Settings.CellSize, Settings.CellSize, Settings.CellSize), Color.White);
            spriteBatch.DrawString(font, sessionData.costTowers[towerType].ToString() + "$",
                new Vector2((int)buttonLocation.X * Settings.CellSize, ((int)buttonLocation.Y + 1) * Settings.CellSize), Color.White);

            if (sessionData.selectedTowerType == towerType)
                spriteBatch.Draw(selectedTexture,
                    new Rectangle((int)buttonLocation.X * Settings.CellSize, (int)buttonLocation.Y * Settings.CellSize, Settings.CellSize, Settings.CellSize), new Color(0, 255, 0));
        }
    }
}

