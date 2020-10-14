﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using UMapx.Colorspace;

namespace UMapx.Imaging
{
    /// <summary>
    /// Defines the alpha channel filter.
    /// </summary>
    [Serializable]
    public class AlphaChannelFilter : IBitmapFilter2
    {
        #region Filter components
        /// <summary>
        /// Initializes the alpha channel filter.
        /// </summary>
        public AlphaChannelFilter() { }
        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="bmData">Bitmap data</param>
        /// <param name="bmSrc">Bitmap data</param>
        public unsafe void Apply(BitmapData bmData, BitmapData bmSrc)
        {
            byte* p = (byte*)bmData.Scan0.ToPointer();
            byte* pSrc = (byte*)bmSrc.Scan0.ToPointer();
            int y, x, width = bmData.Width, height = bmData.Height;

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++, p += 4, pSrc += 4)
                {
                    p[3] = (byte)RGB.Average(pSrc[2], pSrc[1], pSrc[0]);
                }
            }
            return;
        }
        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="Data">Bitmap</param>
        /// <param name="Src">Bitmap</param>
        public void Apply(Bitmap Data, Bitmap Src)
        {
            BitmapData bmData = BitmapConverter.Lock32bpp(Data);
            BitmapData bmSrc = BitmapConverter.Lock32bpp(Src);
            Apply(bmData, bmSrc);
            BitmapConverter.Unlock(Data, bmData);
            BitmapConverter.Unlock(Src, bmSrc);
        }
        #endregion
    }
}