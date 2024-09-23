using SplashKitSDK;

namespace FallingObjectsGame
{
    public class Player
    {
        private Bitmap _playerBitmap;
        public double X { get; private set; }
        public double Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Quit { get; set; }
        public int Lives { get; set; }
        public int Score { get; set; }

        public Player(Window gameWindow)
        {
            _playerBitmap = new Bitmap("player", "player.png");
            Width = _playerBitmap.Width;
            Height = _playerBitmap.Height;

            X = (gameWindow.Width - Width) / 2;
            Y = gameWindow.Height - Height - 10;
            Quit = false;
        }

        public void Move()
        {
            const int SPEED = 8;
            if (SplashKit.KeyDown(KeyCode.LeftKey)) X -= SPEED;
            if (SplashKit.KeyDown(KeyCode.RightKey)) X += SPEED;
            if (SplashKit.KeyDown(KeyCode.EscapeKey)) Quit = true;
        }

        // Expose the player's bitmap so it can be accessed in collision detection
        public Bitmap PlayerBitmap => _playerBitmap;

        public void Draw(Window gameWindow)
        {
            _playerBitmap.Draw(X, Y);

            for (int i = 0; i < Lives; i++)
            {
                gameWindow.FillCircle(Color.Red, 10 + i * 20, 10, 10);
            }

            // Draw score
            gameWindow.DrawText("Score: " + Score, Color.Black, "Arial", 20, 10, 40);
        }
    }
}
