using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MazeBlazeMk3
{
    class Ball
    {
        private Texture2D ballTexture;
        private Rectangle ballRectangle;
        private Rectangle screenBounds;
        private Color ballColor;

        private Vector2 ballPosition;
        private Vector2 ballMotion;
        private const float ballSpeed = 5f;

        public Ball(Rectangle inBounds, Texture2D inTexture)
        {
            this.screenBounds = inBounds;
            this.ballTexture = inTexture;
        }

        public void SetPosition(Vector2 inPosition)
        {
            this.ballPosition = inPosition;
        }

        public Color BallColor
        {
            get
            {
                return ballColor;
            }

            set
            {
                ballColor = value;
            }
        }

        public Rectangle GetBallRectangle()
        {
            return ballRectangle;
        }

        public void Update()
        {
            ballMotion = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                ballMotion.Y = -1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                ballMotion.X = -1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                ballMotion.Y = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                ballMotion.X = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                // set the motion of the ball to 0, i.e. the ball doesn't move
                ballMotion.X = 0;
                ballMotion.Y = 0;
            }

            // If the up arrow key and the right arrow key are pressed
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                // set the motion of the ball to 0, i.e. the ball doesn't move
                ballMotion.X = 0;
                ballMotion.Y = 0;
            }

            // If the down arrow key and the left arrow key are pressed
            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                // set the motion of the ball to 0, i.e. the ball doesn't move
                ballMotion.X = 0;
                ballMotion.Y = 0;
            }

            // If the down arrow key and the right arrow key are pressed
            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                // set the motion of the ball to 0, i.e. the ball doesn't move
                ballMotion.X = 0;
                ballMotion.Y = 0;
            }

            ballMotion *= ballSpeed;
            ballPosition += ballMotion;

            ContainBall();

            ballRectangle = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballTexture.Width, ballTexture.Height);
        }

        private void BrickCollisionHelper(Rectangle newRectangle, Color newColor)
        {
            if (ballColor != newColor && ballRectangle.TouchTopOf(newRectangle))
            {
                ballPosition.Y = ballRectangle.Top - 9;
            }

            if (ballColor != newColor && ballRectangle.TouchBottomOf(newRectangle))
            {
                ballPosition.Y = ballRectangle.Bottom + 4;
            }

            if (ballColor != newColor && ballRectangle.TouchLeftOf(newRectangle))
            {
                ballPosition.X = ballRectangle.Left - 8;
            }

            if (ballColor != newColor && ballRectangle.TouchRightOf(newRectangle))
            {
                ballPosition.X = ballRectangle.Right - 8;
            }
        }

        private void CoinCollisionHelper(Rectangle newRectangle, Color newColor)
        {
            if (ballRectangle.TouchTopOf(newRectangle) ||
                ballRectangle.TouchBottomOf(newRectangle) ||
                ballRectangle.TouchLeftOf(newRectangle) ||
                ballRectangle.TouchRightOf(newRectangle))
            {
                ballColor = newColor;
            }
        }

        public void BrickCollision(Brick brick)
        {
            switch (brick.GetColorValue())
            {
                case 1:
                    BrickCollisionHelper(brick.Rectangle, Color.White);
                    break;
                case 2:
                    BrickCollisionHelper(brick.Rectangle, Color.LimeGreen);
                    break;
                case 3:
                    BrickCollisionHelper(brick.Rectangle, Color.Orange);
                    break;
                case 4:
                    BrickCollisionHelper(brick.Rectangle, Color.Blue);
                    break;
                case 5:
                    BrickCollisionHelper(brick.Rectangle, Color.Purple);
                    break;
                case 6:
                    BrickCollisionHelper(brick.Rectangle, Color.Red);
                    break;
                case 7:
                    BrickCollisionHelper(brick.Rectangle, Color.Yellow);
                    break;
                case 8:
                    BrickCollisionHelper(brick.Rectangle, Color.Gray);
                    break;
            }
        }

        public void CoinCollision(ColorCoin colorCoin)
        {
            switch (colorCoin.GetColorValue())
            {
                case 1:
                    CoinCollisionHelper(colorCoin.Rectangle, Color.White);
                    break;
                case 2:
                    CoinCollisionHelper(colorCoin.Rectangle, Color.LimeGreen);
                    break;
                case 3:
                    CoinCollisionHelper(colorCoin.Rectangle, Color.Orange);
                    break;
                case 4:
                    CoinCollisionHelper(colorCoin.Rectangle, Color.Blue);
                    break;
                case 5:
                    CoinCollisionHelper(colorCoin.Rectangle, Color.Purple);
                    break;
                case 6:
                    CoinCollisionHelper(colorCoin.Rectangle, Color.Red);
                    break;
                case 7:
                    CoinCollisionHelper(colorCoin.Rectangle, Color.Yellow);
                    break;
            }
        }

        public bool CoinCollision(CollectCoin collectCoin)
        {
            return ballRectangle.Intersects(collectCoin.Rectangle);
        }

        public bool SpikeCollision(Spike spike)
        {
            return ballRectangle.Intersects(spike.Rectangle);
        }

        private void ContainBall()
        {
            if (ballPosition.X < 0)
            {
                // set the horizontal ball position to be 0
                ballPosition.X = 0;
            }

            // if the horizontal ball position is greater than the width of the screen
            if (ballPosition.X + ballTexture.Width > screenBounds.Width)
            {
                // set the horizontal position of the ball to be at the edge of the screen
                ballPosition.X = screenBounds.Width - ballTexture.Width;
            }

            // if the vertical ball position is less than 0
            if (ballPosition.Y < 0)
            {
                // set the vertical ball position to be 0
                ballPosition.Y = 0;
            }

            // if the vertical ball position is greater than the height of the screen
            if (ballPosition.Y + ballTexture.Height > screenBounds.Height)
            {
                // set the vertical position of the ball to be at the edge of the screen
                ballPosition.Y = screenBounds.Height - ballTexture.Height;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ballTexture, ballRectangle, ballColor);
        }
    }
}
