using System;
using SplashKitSDK;

namespace FallingObjectsGame
{
    public static class Program
    {
        public static void Main()
        {
            Window gameWindow = new Window("Falling Objects Game", 900, 700);
            Game game = new Game(gameWindow);

            // Main game loop
            while (!game.Quit && !gameWindow.CloseRequested)
            {
                SplashKit.ProcessEvents();
                game.Update();
                game.Draw();
            }

            gameWindow.Close();
        }
    }
}
