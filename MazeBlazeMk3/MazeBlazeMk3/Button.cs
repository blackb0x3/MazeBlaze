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
    class Button
    {
        private Texture2D buttonTexture;
        private Vector2 buttonPosition;
        private Rectangle buttonRectangle;

        private Color buttonColor = new Color(255, 255, 255, 255);

        private SpriteFont buttonFont;

        private Vector2 buttonSize;

        // Controls button transparency levels, while down is true, button transparency increases from 0 to 255
        private bool down;

        private bool isClicked;

        private string buttonText;

        public Button(GraphicsDevice graphics, string inText, Vector2 inPosition, SpriteFont inFont)
        {
            buttonSize = new Vector2(graphics.Viewport.Width / 6.92f, graphics.Viewport.Height / 12f);
            buttonText = inText;
            buttonPosition = inPosition;
            buttonFont = inFont;
            buttonTexture = new Texture2D(graphics, 200, 64);

            Color[] colorData = new Color[buttonTexture.Width * buttonTexture.Height];
            for (int i = 0; i < colorData.Length; i++)
            {
                colorData[i] = Color.Black;
            }
            buttonTexture.SetData(colorData);
        }

        public bool IsClicked()
        {
            return isClicked;
        }

        public void SetIsClicked(bool b)
        {
            isClicked = b;
        }

        public string GetButtonText()
        {
            return buttonText;
        }

        public void Update()
        {
            buttonRectangle = new Rectangle((int)buttonPosition.X,
                                            (int)buttonPosition.Y,
                                            (int)buttonSize.X,
                                            (int)buttonSize.Y);

            Rectangle mouseRectangle = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);

            if (mouseRectangle.Intersects(buttonRectangle))
            {
                if (buttonColor.A == 255)
                {
                    down = false;
                }

                if (buttonColor.A == 0)
                {
                    down = true;
                }

                if (down)
                {
                    buttonColor.A += 3;
                }

                else
                {
                    buttonColor.A -= 3;
                }

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;
                }
            }

            else if (buttonColor.A < 255)
            {
                buttonColor.A += 3;
                isClicked = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(buttonTexture, buttonRectangle, buttonColor);
            spriteBatch.DrawString(buttonFont,
                                   buttonText,
                                   new Vector2(buttonRectangle.X + 4, buttonRectangle.Y),
                                   Color.Red);
        }
    }
}
