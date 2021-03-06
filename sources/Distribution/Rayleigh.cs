﻿using System;
using UMapx.Core;

namespace UMapx.Distribution
{
    /// <summary>
    /// Defines the logarithmic distribution of Rayleigh.
    /// <remarks>
    /// More information can be found on the website:
    /// https://en.wikipedia.org/wiki/Rayleigh_distribution
    /// </remarks>
    /// </summary>
    [Serializable]
    public class Rayleigh : IDistribution
    {
        #region Private data
        private float sigma = 1;
        #endregion;

        #region Rayleigh components
        /// <summary>
        /// Initializes the Rayleigh logarithmic distribution.
        /// </summary>
        public Rayleigh() { }
        /// <summary>
        /// Initializes the Rayleigh logarithmic distribution.
        /// </summary>
        /// <param name="sigma">Scale parameter</param>
        public Rayleigh(float sigma)
        {
            Sigma = sigma;
        }
        /// <summary>
        /// Gets or sets the value of the scale parameter.
        /// </summary>
        public float Sigma
        {
            get
            {
                return this.sigma;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("Invalid argument value");

                this.sigma = value;
            }
        }
        /// <summary>
        /// Gets the support interval of the argument.
        /// </summary>
        public RangeFloat Support
        {
            get
            {
                return new RangeFloat(0, float.PositiveInfinity);
            }
        }
        /// <summary>
        /// Gets the mean value.
        /// </summary>
        public float Mean
        {
            get
            {
                return Maths.Sqrt(Maths.Pi / 2.0f) * sigma;
            }
        }
        /// <summary>
        /// Gets the variance value.
        /// </summary>
        public float Variance
        {
            get
            {
                return (2.0f - Maths.Pi / 2.0f) * Maths.Pow(sigma);
            }
        }
        /// <summary>
        /// Gets the median value.
        /// </summary>
        public float Median
        {
            get
            {
                return sigma * Maths.Sqrt(Maths.Log(4));
            }
        }
        /// <summary>
        /// Gets the mode value.
        /// </summary>
        public float Mode
        {
            get
            {
                return sigma;
            }
        }
        /// <summary>
        /// Gets the value of the asymmetry coefficient.
        /// </summary>
        public float Skewness
        {
            get
            {
                return 2 * Maths.Sqrt(Maths.Pi) * (Maths.Pi - 3) / Maths.Pow(4 - Maths.Pi, 1.5f);
            }
        }
        /// <summary>
        /// Gets the kurtosis coefficient.
        /// </summary>
        public float Excess
        {
            get
            {
                return -(6 * Maths.Pi - 24 * Maths.Pi + 16) / Maths.Pow(4 - Maths.Pi);
            }
        }
        /// <summary>
        /// Returns the value of the probability density function.
        /// </summary>
        /// <param name="x">Value</param>
        /// <returns>float precision floating point number</returns>
        public float Function(float x)
        {
            if (x < 0)
            {
                return 0;
            }
            return x / sigma / sigma * Maths.Exp(-(x * x) / (2 * sigma * sigma));
        }
        /// <summary>
        /// Returns the value of the probability distribution function.
        /// </summary>
        /// <param name="x">Value</param>
        /// <returns>float precision floating point number</returns>
        public float Distribution(float x)
        {
            if (x < 0)
            {
                return 0;
            }
            return 1 - Maths.Exp(-(x * x) / (2 * sigma * sigma));
        }
        /// <summary>
        /// Returns the value of differential entropy.
        /// </summary>
        /// <returns>float precision floating point number</returns>
        public float Entropy
        {
            get
            {
                return 1 + Maths.Log(sigma / Maths.Log(2)) + Maths.Gamma / 2;
            }
        }
        #endregion
    }
}
