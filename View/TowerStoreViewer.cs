using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

class TowerStoreViewer
{
    private SpriteBatch spriteBatch;
    private Dictionary<Vector2, TowerType> towerButtonsLocations;
    private int mapWidth;

    private Dictionary<TowerType, Texture2D> towerTextures;
    private Texture2D slotTexture;

    public TowerStoreViewer(SpriteBatch spriteBatch, Dictionary<Vector2, TowerType> towerButtonsLocations, int mapWidth)
    {
        this.spriteBatch = spriteBatch;
        this.towerButtonsLocations = towerButtonsLocations;
        this.mapWidth = mapWidth;

        FindTowerButtonsLocations();
    }

    private void FindTowerButtonsLocations()
    {
        var lastX = mapWidth + 1;
        var lastY = 1;

        for (int towerIndex = 0; towerIndex < Enum.GetNames(typeof(TowerType)).Length; towerIndex++)
        {
            towerButtonsLocations[new Vector2(lastX, lastY)] = (TowerType)towerIndex;
            lastY += 2;
        }
    }

    public void LoadTextures(Dictionary<TowerType, Texture2D> towerTextures, Texture2D slotTexture)
    {
        this.towerTextures = towerTextures;
        this.slotTexture = slotTexture;
    }

    public void Display()
    {
        foreach (var button in towerButtonsLocations)
        {
            var buttonLocation = button.Key;
            var towerType = button.Value;

            spriteBatch.Draw(slotTexture, new Rectangle((int)buttonLocation.X * Settings.CellSize, (int)buttonLocation.Y * Settings.CellSize, Settings.CellSize, Settings.CellSize), Color.White);
            spriteBatch.Draw(towerTextures[towerType], new Rectangle((int)buttonLocation.X * Settings.CellSize, (int)buttonLocation.Y * Settings.CellSize, Settings.CellSize, Settings.CellSize), Color.White);
        }
        
    }
}

