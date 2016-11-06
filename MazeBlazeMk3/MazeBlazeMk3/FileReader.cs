using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MazeBlazeMk3
{
    static class FileReader
    {
        public static int[,] GetArrayFromFile(string filePath)
        {
            String input = File.ReadAllText(filePath);

            int i = 0, j = 0;
            int[,] result = new int[20, 37];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }

            return result;
        }

        public static bool[,] GetBoolFromFile(string filePath)
        {
            String input = File.ReadAllText(filePath);

            int i = 0, j = 0;
            bool[,] result = new bool[20, 37];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = Convert.ToBoolean(int.Parse(col.Trim()));
                    j++;
                }
                i++;
            }
            return result;
        }
    }
}
