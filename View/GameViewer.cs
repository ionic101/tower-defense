﻿using Microsoft.Xna.Framework.Graphics;

class GameViewer
{
    public MapViewer MapViewer { get; private set; }
    public TowersViewer TowersViewer { get; private set; }
    public SelecterViewer SelecterViewer { get; private set; }

    public void Init(SpriteBatch spriteBatch, GameSessionData sessionData)
    {
        TowersViewer = new TowersViewer(spriteBatch, sessionData);
        MapViewer = new MapViewer(spriteBatch, sessionData);
        SelecterViewer = new SelecterViewer(spriteBatch, sessionData);
    }

    public void Display()
    {
        MapViewer.Display();
        TowersViewer.Display();
        SelecterViewer.Display();
    }
}