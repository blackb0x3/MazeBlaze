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
    class Map
    {
        private const int TILESIZE = 32;
        private Vector2 startPosition;
        private List<Brick> brickList = new List<Brick>();
        private List<ColorCoin> colorCoinList = new List<ColorCoin>();
        private List<CollectCoin> collectCoinList = new List<CollectCoin>();
        private List<Spike> spikeList = new List<Spike>();

        public List<Brick> GetBrickList()
        {
            return brickList;
        }

        public List<ColorCoin> GetColorList()
        {
            return colorCoinList;
        }

        public List<CollectCoin> GetCollectList()
        {
            return collectCoinList;
        }

        public void RemoveCoin(byte index)
        {
            this.collectCoinList.RemoveAt(index);
        }

        public List<Spike> GetSpikeList()
        {
            return spikeList;
        }

        private int[,] bricks, colorCoins;
        private bool[,] spikes, collectCoins;

        private double levelTime;

        public double GetLevelTime()
        {
            return levelTime;
        }

        public Vector2 GetStartPosition()
        {
            return this.startPosition;
        }

        private Flag flag;

        public Flag GetFlag()
        {
            return flag;
        }

        public Map(int[,] inBricks, int[,] inColorCoins, bool[,] inSpikes, bool[,] inCollectCoins, double inTime, Vector2 startPosition, Vector2 finishLocation)
        {
            this.bricks = inBricks;
            this.colorCoins = inColorCoins;
            this.spikes = inSpikes;
            this.collectCoins = inCollectCoins;
            this.levelTime = inTime;
            this.startPosition = startPosition;
            this.flag = new Flag(new Rectangle((int)finishLocation.X, (int)finishLocation.Y, TILESIZE, TILESIZE));
        }

        public void GenerateLevel(int rank)
        {
            GenerateBricks();
            GenerateColorCoins();

            if (rank == 2)
            {
                GenerateSpikes();
            }

            else if (rank == 3)
            {
                GenerateCollectCoins();
            }

            else if (rank == 4)
            {
                GenerateSpikes();
                GenerateCollectCoins();
            }
        }

        private void GenerateBricks()
        {
            for (int x = 0; x < bricks.GetLength(1); x++)
            {
                for (int y = 0; y < bricks.GetLength(0); y++)
                {
                    if (bricks[y, x] > 0)
                    {
                        brickList.Add(new Brick(bricks[y, x], new Rectangle(x * TILESIZE, y * TILESIZE, TILESIZE, TILESIZE)));
                    }
                }
            }
        }

        private void GenerateColorCoins()
        {
            for (int x = 0; x < colorCoins.GetLength(1); x++)
            {
                for (int y = 0; y < colorCoins.GetLength(0); y++)
                {
                    if (colorCoins[y, x] > 0)
                    {
                        colorCoinList.Add(new ColorCoin(colorCoins[y, x], new Rectangle(x * TILESIZE, y * TILESIZE, TILESIZE, TILESIZE)));
                    }
                }
            }
        }

        private void GenerateSpikes()
        {
            for (int x = 0; x < spikes.GetLength(1); x++)
            {
                for (int y = 0; y < spikes.GetLength(0); y++)
                {
                    if (spikes[y, x])
                    {
                        spikeList.Add(new Spike(new Rectangle(x * TILESIZE, y * TILESIZE, TILESIZE, TILESIZE)));
                    }
                }
            }
        }

        private void GenerateCollectCoins()
        {
            for (int x = 0; x < collectCoins.GetLength(1); x++)
            {
                for (int y = 0; y < collectCoins.GetLength(0); y++)
                {
                    if (collectCoins[y, x])
                    {
                        collectCoinList.Add(new CollectCoin(new Rectangle(x * TILESIZE, y * TILESIZE, TILESIZE, TILESIZE)));
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Brick brick in brickList)
            {
                brick.Draw(spriteBatch);
            }

            foreach (ColorCoin coin in colorCoinList)
            {
                coin.Draw(spriteBatch);
            }

            foreach (CollectCoin coin in collectCoinList)
            {
                coin.Draw(spriteBatch);
            }

            foreach (Spike spike in spikeList)
            {
                spike.Draw(spriteBatch);
            }

            flag.Draw(spriteBatch);
        }
    }
}
