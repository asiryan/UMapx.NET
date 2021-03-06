﻿using System;
using UMapx.Core;

namespace UMapx.Window
{
    /// <summary>
    /// Defines the Blackman-Harris window function.
    /// </summary>
    [Serializable]
    public class BlackmanHarris : WindowBase
    {
        #region Window components
        /// <summary>
        /// Initializes the Blackman-Harris window function.
        /// </summary>
        /// <param name="frameSize">Window size</param>
        public BlackmanHarris(int frameSize)
        {
            this.FrameSize = frameSize;
        }
        /// <summary>
        /// Returns the value of a window function.
        /// </summary>
        /// <param name="x">Argument</param>
        /// <param name="frameSize">Window size</param>
        /// <returns>float precision floating point number</returns>
        public override float Function(float x, int frameSize)
        {
            return 0.35875f - 0.48829f * Cosine.cosinefunc(2 * x, frameSize) + 0.14128f * Cosine.cosinefunc(4 * x, frameSize) - 0.01168f * Cosine.cosinefunc(6 * x, frameSize);
        }
        /// <summary>
        /// Returns the window function.
        /// </summary>
        /// <returns>Array</returns>
        public override float[] GetWindow(int frameSize)
        {
            float t = frameSize - 1;
            float[] x = Matrice.Compute(0, t, 1);
            return this.Function(x, frameSize);
        }
        #endregion
    }
}
