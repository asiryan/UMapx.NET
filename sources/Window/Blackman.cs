﻿using System;
using UMapx.Core;

namespace UMapx.Window
{
    /// <summary>
    /// Defines the Blackman window function.
    /// </summary>
    [Serializable]
    public class Blackman : WindowBase
    {
        #region Window components
        /// <summary>
        /// Initializes the Blackman window function.
        /// </summary>
        /// <param name="frameSize">Window size</param>
        public Blackman(int frameSize)
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
            return 0.42f - 0.5f * Cosine.cosinefunc(2 * x, frameSize) + 0.08f * Cosine.cosinefunc(4 * x, frameSize);
        }
        /// <summary>
        /// Returns the window function.
        /// </summary>
        /// <param name="frameSize">Window size</param>
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
