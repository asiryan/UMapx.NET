﻿using System;
using UMapx.Core;

namespace UMapx.Distribution
{
    /// <summary>
    /// Defines the geometric distribution.
    /// <remarks>
    /// More information can be found on the website:
    /// https://en.wikipedia.org/wiki/Geometric_distribution
    /// </remarks>
    /// </summary>
    [Serializable]
    public class Geometric : IDistribution
    {
        #region Private data
        private float p = 0.2f;
        private float q = 0.8f;
        #endregion

        #region Geometric components
        /// <summary>
        /// Initializes the geometric distribution.
        /// </summary>
        public Geometric() { }
        /// <summary>
        /// Initializes the geometric distribution.
        /// </summary>
        /// <param name="p">Probability of "success" [0, 1]</param>
        public Geometric(float p)
        {
            P = p;
        }
        /// <summary>
        /// Gets or sets the probability value of "success" [0, 1].
        /// </summary>
        public float P
        {
            get
            {
                return this.p;
            }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentException("Invalid argument value");

                this.p = value;
                this.q = 1 - this.p;
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
                return q / p;
            }
        }
        /// <summary>
        /// Gets the variance value.
        /// </summary>
        public float Variance
        {
            get
            {
                return q / p / p;
            }
        }
        /// <summary>
        /// Gets the mode value.
        /// </summary>
        public float Mode
        {
            get
            {
                return 0;
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
                return (2 - p) / Maths.Sqrt(1 - p);
            }
        }
        /// <summary>
        /// Gets the kurtosis coefficient.
        /// </summary>
        public float Excess
        {
            get
            {
                return 6 + p * p / q;
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
            return Maths.Pow(q, x) * p;
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
            return 1 - Maths.Pow(q, x);
        }
        /// <summary>
        /// Returns the value of differential entropy.
        /// </summary>
        /// <returns>float precision floating point number</returns>
        public float Entropy
        {
            get
            {
                return -Maths.Log2(p) - q / p * Maths.Log2(q);
            }
        }
        #endregion
    }
}
