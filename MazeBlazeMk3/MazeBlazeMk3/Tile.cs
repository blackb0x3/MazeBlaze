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
    class Tile
    {
        protected Texture2D tileTexture;

        private Rectangle tileRectangle;
        private static ContentManager content;

        public Rectangle Rectangle
        {
            get
            {
                return tileRectangle;
            }

            protected set
            {
                tileRectangle = value;
            }
        }

        public static ContentManager Content
        {
            protected get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tileTexture, tileRectangle, Color.White);
        }
    }

    class Brick : Tile
    {
        private int colorValue;

        public Brick(int i, Rectangle inRect)
        {
            tileTexture = Content.Load<Texture2D>("Images/Bricks/brick" + i.ToString());
            this.Rectangle = inRect;
            this.colorValue = i;
        }

        public int GetColorValue()
        {
            return colorValue;
        }
    }

    class CollectCoin : Tile
    {
        private bool isVisible;

        public CollectCoin(Rectangle inRect)
        {
            tileTexture = Content.Load<Texture2D>("Images/Other/coinGold");
            this.Rectangle = inRect;
            this.IsVisible = true;
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                isVisible = value;
            }
        }
    }

    class ColorCoin : Tile
    {
        private int colorValue;

        public ColorCoin(int i, Rectangle inRect)
        {
            tileTexture = Content.Load<Texture2D>("Images/Coins/coin" + i.ToString());
            this.Rectangle = inRect;
            this.colorValue = i;
        }

        public int GetColorValue()
        {
            return colorValue;
        }
    }

    class Spike : Tile
    {
        public Spike(Rectangle inRect)
        {
            tileTexture = Content.Load<Texture2D>("Images/Other/spikes");
            this.Rectangle = inRect;
        }
    }

    class Flag : Tile
    {
        public Flag(Rectangle inRect)
        {
            tileTexture = Content.Load<Texture2D>("Images/Other/finish");
            this.Rectangle = inRect;
        }
    }
}
