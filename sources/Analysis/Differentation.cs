﻿using System;
using UMapx.Core;

namespace UMapx.Analysis
{
    /// <summary>
    /// Defines a class that implements numerical differentiation.
    /// </summary>
    [Serializable]
    public class Differentation
    {
        #region Private data
        private int points;
        #endregion

        #region Components
        /// <summary>
        /// Initializes a class that implements numerical differentiation.
        /// </summary>
        /// <param name="points">Number of interpolation points</param>
        public Differentation(int points)
        {
            this.Points = points;
        }
        /// <summary>
        /// Gets or sets the number of interpolation points.
        /// </summary>
        public int Points
        {
            get
            {
                return this.points;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid argument value");

                this.points = value;
            }
        }
        /// <summary>
        /// Returns the value of a derived function.
        /// </summary>
        /// <param name="function">Continuous function delegate</param>
        /// <param name="x">Argument value</param>
        /// <param name="h">Step</param>
        /// <param name="order">Order</param>
        /// <returns>float precision floating point number</returns>
        public float Compute(IFloat function, float x, float h, int order)
        {
            // exception
            if (order > this.points)
                throw new Exception("The order of the derivative cannot be greater than the number of interpolation points");
            if (order < 0)
                throw new Exception("The derivative order cannot be less than 0");

            // Create the interpolation points
            int length = this.points + 1;
            float[,] coefficients = Differentation.GetCoefficients(length);
            float sum = 0.0f;

            // do job
            for (int i = 0, center = 0; i < length; i++)
            {
                sum += coefficients[order, i] * function(x + center * h);
                center++;
            }

            // result
            return sum / (float)Math.Pow(h, order);
        }
        /// <summary>
        /// Returns the value of a derived function.
        /// </summary>
        /// <param name="y">Function vector</param>
        /// <param name="index">Index of argument</param>
        /// <param name="h">Step</param>
        /// <param name="order">Order</param>
        /// <returns>float precision floating point number</returns>
        public float Compute(float[] y, int index, float h, int order)
        {
            // exception
            if (order > this.points)
                throw new Exception("The order of the derivative cannot be greater than the number of interpolation points");
            if (order < 0)
                throw new Exception("The derivative order cannot be less than 0");

            // Create the interpolation points
            int length = this.points + 1;
            float[,] coefficients = Differentation.GetCoefficients(length);
            float sum = 0.0f;

            // do job
            for (int i = 0, center = 0; i < length; i++)
            {
                sum += coefficients[order, i] * y[index + i];
                center++;
            }

            // result
            return sum / (float)Math.Pow(h, order);
        }
        /// <summary>
        /// Returns the value of a derived function.
        /// </summary>
        /// <param name="function">Continuous function delegate</param>
        /// <param name="x">Argument value</param>
        /// <param name="h">Step</param>
        /// <param name="order">Order</param>
        /// <returns>Complex number</returns>
        public Complex32 Compute(IComplex function, Complex32 x, Complex32 h, int order)
        {
            // exception
            if (order > this.points)
                throw new Exception("The order of the derivative cannot be greater than the number of interpolation points");
            if (order < 0)
                throw new Exception("The derivative order cannot be less than 0");

            // Create the interpolation points
            int length = this.points + 1;
            float[,] coefficients = Differentation.GetCoefficients(length);
            Complex32 sum = 0.0;

            // do job
            for (int i = 0, center = 0; i < length; i++)
            {
                sum += coefficients[order, i] * function(x + center * h);
                center++;
            }

            // result
            return sum / Maths.Pow(h, order);
        }
        /// <summary>
        /// Returns the value of a derived function.
        /// </summary>
        /// <param name="y">Function vector</param>
        /// <param name="index">Index of argument</param>
        /// <param name="h">Step</param>
        /// <param name="order">Order</param>
        /// <returns>Complex number</returns>
        public Complex32 Compute(Complex32[] y, int index, float h, int order)
        {
            // exception
            if (order > this.points)
                throw new Exception("The order of the derivative cannot be greater than the number of interpolation points");
            if (order < 0)
                throw new Exception("The derivative order cannot be less than 0");

            // Create the interpolation points
            int length = this.points + 1;
            float[,] coefficients = Differentation.GetCoefficients(length);
            Complex32 sum = 0.0;

            // do job
            for (int i = 0, center = 0; i < length; i++)
            {
                sum += coefficients[order, i] * y[index + i];
                center++;
            }

            // result
            return sum / Math.Pow(h, order);
        }
        #endregion

        #region Static voids
        /// <summary>
        /// Returns the matrix of interpolation coefficients.
        /// </summary>
        /// <param name="points">Number of points</param>
        /// <returns>Matrix</returns>
        public static float[,] GetCoefficients(int points)
        {
            // Compute difference coefficient table
            float fac = Special.Factorial(points);
            float[,] deltas = new float[points, points];
            float h, delta;
            int j, k;

            // do job
            for (j = 0; j < points; j++)
            {
                h = 1.0f;
                delta = j;

                for (k = 0; k < points; k++)
                {
                    deltas[j, k] = h / Special.Factorial(k);
                    h *= delta;
                }
            }

            // matrix invert
            deltas = Matrice.Invert(deltas);

            //// rounding
            //for (j = 0; j < points; j++)
            //    for (k = 0; k < points; k++)
            //        deltas[j, k] = (Math.Round(deltas[j, k] * fac, MidpointRounding.AwayFromZero)) / fac;

            return deltas;
        }
        #endregion
    }
}
