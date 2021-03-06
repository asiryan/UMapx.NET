﻿using System;
using UMapx.Core;

namespace UMapx.Wavelet
{
    /// <summary>
    /// Defines the continuous Shannon wavelet.
    /// </summary>
    [Serializable]
    public class ShannonWavelet : IFloatWavelet
    {
        #region Wavelet components
        /// <summary>
        /// Initializes the continuous Shannon wavelet.
        /// </summary>
        public ShannonWavelet() { }
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
            float t = x / 2;
            return Special.Sinc(t) * (float)Math.Cos(3 * Math.PI * t);
        }
        #endregion
    }
}
