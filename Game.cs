using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace FallingObjectsGame
{
    public class Game
    {
        private List<FallingObject> fallingObjects;
        private Player player;
        private int score;
        private int lives;
        private Random rand;
        private Window _gameWindow;
        public bool Quit
        {
            get { return player.Quit; }
        }


        public Game(Window window)
        {
            _gameWindow = window;
            fallingObjects = new List<FallingObject>();
            player = new Player(_gameWindow);
            score = 0;
            lives = 5;
            rand = new Random();
        }

        public void Update()
        {
            // Update player movement
            player.Move();

            // Move falling objects
            for (int i = 0; i < fallingObjects.Count; i++)
            {
                fallingObjects[i].Move();
                if (fallingObjects[i].CollidesWith(player))
                {
                    fallingObjects.RemoveAt(i);
                    score += 1;
                    i--;
                }
                else if (fallingObjects[i].IsOffScreen(_gameWindow.Height))
                {
                    fallingObjects.RemoveAt(i);
                    lives--;
                    i--;

                    if (lives <= 0)
                    {
                        string gameOverMessage = "Game Over! Your score: " + score;

                        // Clear the screen and draw the Game Over message in the center
                        _gameWindow.Clear(Color.White);
                        int messageX = (_gameWindow.Width - SplashKit.TextWidth(gameOverMessage, "Arial", 40)) / 2;
                        int messageY = (_gameWindow.Height - SplashKit.TextHeight(gameOverMessage, "Arial", 40)) / 2;
                        _gameWindow.DrawText(gameOverMessage, Color.BlueViolet, "Arial", 80, messageX, messageY);

                        _gameWindow.Refresh();

                        SplashKit.Delay(5000);
                        player.Quit = true;
                    }
                }
            }

            // Add new falling objects randomly
            if (rand.Next(0, 100) < 5)
            {
                int x = rand.Next(0, _gameWindow.Width - 30);
                fallingObjects.Add(new FallingObject(x, 0));
            }
        }

        public void Draw()
        {
            _gameWindow.Clear(Color.White);

            // Draw falling objects
            foreach (var obj in fallingObjects)
            {
                obj.Draw();
            }

            // Draw the player
            player.Draw(_gameWindow);

            // Display score and lives
            SplashKit.DrawText("Score: " + score, Color.Black, 10, 10);
            SplashKit.DrawText("Lives: " + lives, Color.Black, 10, 30);

            _gameWindow.Refresh(60);
        }
    }
}
