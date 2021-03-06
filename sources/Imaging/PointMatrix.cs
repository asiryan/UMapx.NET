﻿using System;
using System.Threading.Tasks;
using UMapx.Core;

namespace UMapx.Imaging
{
    /// <summary>
    /// Uses to work with point matrices.
    /// </summary>
    public static class PointMatrix
    {
        #region Filters
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] FlipY(int width, int height)
        {
            PointInt[,] matrix = new PointInt[width, height];

            Parallel.For(0, width, x =>
            {
                int y;

                for (y = 0; y < height; y++)
                {

                    matrix[x, y].X = x;
                    matrix[x, y].Y = height - y - 1;
                }
            }
            );

            return matrix;
        }
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] FlipX(int width, int height)
        {
            PointInt[,] matrix = new PointInt[width, height];

            Parallel.For(0, width, x =>
            {
                int y;

                for (y = 0; y < height; y++)
                {

                    matrix[x, y].X = width - x - 1;
                    matrix[x, y].Y = y;
                }
            }
            );

            return matrix;
        }
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="value">Offset</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] ShiftX(int width, int height, int value)
        {
            PointInt[,] matrix = new PointInt[width, height];

            Parallel.For(0, width, x =>
            {
                int y;

                for (y = 0; y < height; y++)
                {

                    matrix[x, y].X = Maths.Mod(x + value, width);
                    matrix[x, y].Y = y;
                }
            }
            );

            return matrix;
        }
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="value">Offset</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] ShiftY(int width, int height, int value)
        {
            PointInt[,] matrix = new PointInt[width, height];

            Parallel.For(0, width, x =>
            {
                int y;

                for (y = 0; y < height; y++)
                {

                    matrix[x, y].X = x;
                    matrix[x, y].Y = Maths.Mod(y + value, height);
                }
            }
            );

            return matrix;
        }
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="value">Value [0, 100]</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] Noise(int width, int height, int value)
        {
            PointInt[,] noise = new PointInt[width, height];
            int y, x, newX, newY;
            int nHalf = value / 2;
            Random rnd = new Random();

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    newX = rnd.Next(value) - nHalf;

                    if (x + newX > 0 && x + newX < width)
                        noise[x, y].X = newX;
                    else
                        noise[x, y].X = 0;

                    newY = rnd.Next(value) - nHalf;

                    if (y + newY > 0 && y + newY < width)
                        noise[x, y].Y = newY;
                    else
                        noise[x, y].Y = 0;
                }
            }
            return noise;
        }
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="value">Value [0, 100]</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] Pixelate(int width, int height, int value)
        {
            PointInt[,] pixelate = new PointInt[width, height];

            Parallel.For(0, width, x =>
            {
                int y, newX, newY;

                for (y = 0; y < height; y++)
                {
                    newX = (int)(value - x % value);
                    newY = (int)(value - y % value);

                    pixelate[x, y].X = newX - value;
                    pixelate[x, y].Y = newY - value;
                }
            }
            );

            return pixelate;
        }
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="value">Value [0, 100]</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] Grid(int width, int height, int value)
        {
            PointInt[,] grid = new PointInt[width, height];

            Parallel.For(0, width, x =>
            {
                int y, newX, newY;

                for (y = 0; y < height; y++)
                {
                    newX = (int)(value - x % value);
                    newY = (int)(value - y % value);

                    if (newX == value)
                        grid[x, y].X = -x;
                    else
                        grid[x, y].X = newX - value;

                    if (newY == value)
                        grid[x, y].Y = -y;
                    else
                        grid[x, y].Y = newY - value;
                }
            }
            );

            return grid;
        }
        /// <summary>
        /// Returns the point matrix.
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="value">Value [0, 100]</param>
        /// <returns>Array of ordered pairs of X and Y</returns>
        public static PointInt[,] Water(int width, int height, int value)
        {
            PointInt[,] water = new PointInt[width, height];
            float pix = 2.0f * Maths.Pi / 127.5f;

            Parallel.For(0, width, x =>
            {
                int y;
                float x0, y0;

                y0 = value * Maths.Cos(pix * x);

                for (y = 0; y < height; y++)
                {
                    x0 = value * Maths.Sin(pix * y);

                    water[x, y].X = (int)Maths.Mod(x + x0, width);
                    water[x, y].Y = (int)Maths.Mod(y + y0, height);
                }
            }
            );

            return water;
        }
        #endregion
    }
}
