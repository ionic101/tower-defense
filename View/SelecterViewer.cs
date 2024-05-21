﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Runtime;

class SelecterViewer
{
    private SpriteBatch spriteBatch;
    private Dictionary<CellType, Texture2D> _textures;
    private GameSessionData sessionData;

    private Texture2D texture;

    public SelecterViewer(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        this.spriteBatch = spriteBatch;
        this.sessionData = sessionData;
    }

    public void LoadTexture(Texture2D texture)
    {
        this.texture = texture;
    }

    public void Display()
    {

        spriteBatch.Draw(texture,
                    new Rectangle((int)sessionData.selectedCellCoords.X * Settings.CellSize, (int)sessionData.selectedCellCoords.Y * Settings.CellSize, Settings.CellSize, Settings.CellSize),
                    color: Color.White);
    }
}

