﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


class PlayerController
{
    private GameSessionData sessionData;
    private bool isLeftButtonPressed = false;
    private int clickedCoordX;
    private int clickedCoordY;

    public PlayerController(GameSessionData sessionData)
    {
        this.sessionData = sessionData;
    }

    public void ListenEvents()
    {
        MouseState mouseState = Mouse.GetState();

        sessionData.selectedCellCoords.X = mouseState.X / Settings.CellSize;
        sessionData.selectedCellCoords.Y = mouseState.Y / Settings.CellSize;

        if (!isLeftButtonPressed && mouseState.LeftButton == ButtonState.Pressed)
        {
            if (mouseState.X > 0 && mouseState.X <= Settings.ScreenWidth
                && mouseState.Y > 0 && mouseState.Y <= Settings.ScreenHeight)
            {
                clickedCoordX = mouseState.X;
                clickedCoordY = mouseState.Y;
                isLeftButtonPressed = true;
            }
        }
        else if (isLeftButtonPressed && mouseState.LeftButton == ButtonState.Released)
        {
            sessionData.SpawnTower(clickedCoordX / Settings.CellSize, clickedCoordY / Settings.CellSize);
            isLeftButtonPressed = false;
        }
    }
}
