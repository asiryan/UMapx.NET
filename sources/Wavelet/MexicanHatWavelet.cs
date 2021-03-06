﻿using System;

namespace UMapx.Wavelet
{
    /// <summary>
    /// Defines the continuous Mexican hat wavelet.
    /// </summary>
    [Serializable]
    public class MexicanHatWavelet : IFloatWavelet
    {
        #region Wavelet components
        /// <summary>
        /// Initializes the continuous Mexican hat wavelet.
        /// </summary>
        public MexicanHatWavelet() { }
        /// <summary>
        /// Returns the value of the scaling function.
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Function</returns>
        public float Scaling(float x)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// Returns the value of the wavelet function.
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Function</returns>
        public float Wavelet(float x)
        {
            float x2 = x * x;
            return 2.0f / (float)(Math.Sqrt(3) * Math.Pow(Math.PI, 0.25)) * (1 - x2) * (float)Math.Exp(-x2 / 2);
        }
        #endregion
    }
}
