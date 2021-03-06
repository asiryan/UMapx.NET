﻿using System;
using UMapx.Core;

namespace UMapx.Distribution
{
    /// <summary>
    /// Defines the Gamma-distribution.
    /// <remarks>
    /// More information can be found on the website:
    /// https://en.wikipedia.org/wiki/Gamma_distribution
    /// </remarks>
    /// </summary>
    [Serializable]
    public class Gamma : IDistribution
    {
        #region Private data
        private float thetta = 1;
        private float k = 1;
        #endregion

        #region Gamma components
        /// <summary>
        /// Initializes the Gamma-distribution.
        /// </summary>
        public Gamma() { }
        /// <summary>
        /// Initializes the Gamma-distribution.
        /// </summary>
        /// <param name="thetta">Parameter θ (0, +inf)</param>
        /// <param name="k">Parameter k (0, +inf)</param>
        public Gamma(float thetta, float k)
        {
            Thetta = thetta; K = k;
        }
        /// <summary>
        /// Gets or sets the parameter θ (0, +inf).
        /// </summary>
        public float Thetta
        {
            get
            {
                return this.thetta;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid argument value");

                this.thetta = value;
            }
        }
        /// <summary>
        /// Gets or sets the parameter k (0, +inf).
        /// </summary>
        public float K
        {
            get
            {
                return this.k;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid argument value");

                this.k = value;
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
                return thetta * k;
            }
        }
        /// <summary>
        /// Gets the variance value.
        /// </summary>
        public float Variance
        {
            get
            {
                return k * thetta * thetta;
            }
        }
        /// <summary>
        /// Gets the mode value.
        /// </summary>
        public float Mode
        {
            get
            {
                if (k >= 1)
                {
                    return (k - 1) * thetta;
                }
                return float.NaN;
            }
        }
        /// <summary>
        /// Gets the median value.
        /// </summary>
        public float Median
        {
            get { throw new NotSupportedException(); }
        }
        /// <summary>
        /// Gets the value of the asymmetry coefficient.
        /// </summary>
        public float Skewness
        {
            get
            {
                return 2 / (float)Math.Sqrt(k);
            }
        }
        /// <summary>
        /// Gets the kurtosis coefficient.
        /// </summary>
        public float Excess
        {
            get
            {
                return 6.0f / k;
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
            return (float)Math.Pow(x, k - 1) * (float)Math.Exp(-x / thetta) / (Special.Gamma(k) * (float)Math.Pow(thetta, k));
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
            return Special.GammaP(k, x / thetta);
        }
        /// <summary>
        /// Returns the value of differential entropy.
        /// </summary>
        /// <returns>float precision floating point number</returns>
        public float Entropy
        {
            get
            {
                return k * thetta + (1 - k) * (float)Math.Log(thetta) + Special.GammaLog(k); // + (1 - k) * Special.Ksi(k);
            }
        }
        #endregion
    }
}
