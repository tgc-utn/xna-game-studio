#region File Description
//-----------------------------------------------------------------------------
// MainMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using GameStateManagement;
#endregion

namespace MarbleMazeGame
{
    class MainMenuScreen : MenuScreen
    {
        #region Initializations
        public MainMenuScreen()
            : base("")
        {
            // Create our menu entries.
            MenuEntry startGameMenuEntry = new MenuEntry("Play");
            MenuEntry highScoreMenuEntry = new MenuEntry("High Score");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            // Hook up menu event handlers.
            startGameMenuEntry.Selected += StartGameMenuEntrySelected;
            highScoreMenuEntry.Selected += HighScoreMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(startGameMenuEntry);
            MenuEntries.Add(highScoreMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }
        #endregion

        #region Update
        /// <summary>
        /// Respond to "High Score" Item Selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HighScoreMenuEntrySelected(object sender, EventArgs e)
        {
            foreach (GameScreen screen in ScreenManager.GetScreens())
                screen.ExitScreen();

            ScreenManager.AddScreen(new BackgroundScreen(), null);
            ScreenManager.AddScreen(new HighScoreScreen(), null);
        }

        /// <summary>
        /// Respond to "Play" Item Selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StartGameMenuEntrySelected(object sender, EventArgs e)
        {
            foreach (GameScreen screen in ScreenManager.GetScreens())
                screen.ExitScreen();

            ScreenManager.AddScreen(new LoadingAndInstructionScreen(), null);
        }

        /// <summary>
        /// Respond to "Exit" Item Selection
        /// </summary>
        /// <param name="playerIndex"></param>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            HighScoreScreen.SaveHighscore();

            ScreenManager.Game.Exit();
        }
        #endregion
    }
}
