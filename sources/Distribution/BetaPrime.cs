﻿using System;
using UMapx.Core;

namespace UMapx.Distribution
{
    /// <summary>
    /// Defines the beta distribution of the second kind.
    /// <remarks>
    /// More information can be found on the website:
    /// https://en.wikipedia.org/wiki/Beta_prime_distribution
    /// </remarks>
    /// </summary>
    [Serializable]
    public class BetaPrime : IDistribution
    {
        #region Private data
        private float alpha = 1; // shape (α)
        private float beta = 1;  // shape (β)
        #endregion

        #region Beta-prime components
        /// <summary>
        /// Initializes beta distribution of the second kind.
        /// </summary>
        /// <param name="alpha">Parameter α (0, +inf)</param>
        /// <param name="beta">Parameter β (0, +inf)</param>
        public BetaPrime(float alpha, float beta)
        {
            Alpha = alpha; Beta = beta;
        }
        /// <summary>
        /// Gets or sets the value of the parameter α ∈ (0, +inf).
        /// </summary>
        public float Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid argument value");

                this.alpha = value;
            }
        }
        /// <summary>
        /// Gets or sets the value of the parameter β ∈ (0, +inf).
        /// </summary>
        public float Beta
        {
            get
            {
                return beta;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid argument value");

                this.beta = value;
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
                if (beta > 1)
                {
                    return alpha / (beta - 1);
                }

                return float.PositiveInfinity;
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
        /// Gets the mode value.
        /// </summary>
        public float Mode
        {
            get
            {
                if (alpha >= 1)
                {
                    return (alpha - 1) / (beta + 1);
                }

                return 0.0f;
            }
        }
        /// <summary>
        /// Gets the variance value.
        /// </summary>
        public float Variance
        {
            get
            {
                if (beta > 2.0)
                {
                    float num = alpha * (alpha + beta - 1);
                    float den = (beta - 2) * (float)Math.Pow(beta - 1, 2);
                    return num / den;
                }
                else if (beta > 1.0)
                {
                    return float.PositiveInfinity;
                }

                return float.NaN;
            }
        }
        /// <summary>
        /// Gets the value of the asymmetry coefficient.
        /// </summary>
        public float Skewness
        {
            get { throw new NotSupportedException(); }
        }
        /// <summary>
        /// Gets the kurtosis coefficient.
        /// </summary>
        public float Excess
        {
            get { throw new NotSupportedException(); }
        }
        /// <summary>
        /// Gets the value of entropy.
        /// </summary>
        public float Entropy
        {
            get { throw new NotSupportedException(); }
        }
        /// <summary>
        /// Returns the value of the probability distribution function.
        /// </summary>
        /// <param name="x">Value</param>
        /// <returns>float precision floating point number</returns>
        public float Distribution(float x)
        {
            if (x <= 0)
            {
                return 0;
            }
            return Special.BetaIncomplete(alpha, beta, x / (1 + x));
        }
        /// <summary>
        /// Returns the value of the probability density function.
        /// </summary>
        /// <param name="x">Value</param>
        /// <returns>float precision floating point number</returns>
        public float Function(float x)
        {
            if (x <= 0)
            {
                return 0;
            }

            float num = (float)Math.Pow(x, alpha - 1) * (float)Math.Pow(1 + x, -alpha - beta);
            float den = Special.Beta(alpha, beta);
            return num / den;
        }
        #endregion
    }
}
