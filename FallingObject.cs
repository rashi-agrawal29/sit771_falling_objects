using SplashKitSDK;

namespace FallingObjectsGame
{
    public class FallingObject
    {
        private Bitmap _objectBitmap;
        private double X, Y;
        private const double Speed = 3;

        public FallingObject(double x, double y)
        {
            _objectBitmap = new Bitmap("fruit", "fruit.png");
            X = x;
            Y = y;
        }

        public void Move()
        {
            Y += Speed;
        }

        public bool CollidesWith(Player player)
        {
            // Use SplashKit's BitmapCollision method to check collision with player's bitmap
            return SplashKit.BitmapCollision(_objectBitmap, X, Y,player.PlayerBitmap, player.X, player.Y);
        }

        public bool IsOffScreen(double screenHeight)
        {
            return Y > screenHeight;
        }

        public void Draw()
        {
            _objectBitmap.Draw(X, Y);
        }
    }
}
