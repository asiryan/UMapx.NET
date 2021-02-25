﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using UMapx.Core;

namespace UMapx.Imaging
{
    /// <summary>
    /// Defines the opening filter.
    /// </summary>
    [Serializable]
    public class Opening : IBitmapFilter2, IBitmapFilter
    {
        #region Private data
        private Erosion erosion = new Erosion();
        private Dilatation dilatation = new Dilatation();
        #endregion

        #region Filter components
        /// <summary>
        /// Initializes the opening filter.
        /// </summary>
        /// <param name="radius">Radius</param>
        public Opening(int radius = 3)
        {
            erosion = new Erosion(radius);
            dilatation = new Dilatation(radius);
        }
        /// <summary>
        /// Initializes the opening filter.
        /// </summary>
        /// <param name="width">Filter width</param>
        /// <param name="height">Filter height</param>
        public Opening(int width, int height)
        {
            erosion = new Erosion(width, height);
            dilatation = new Dilatation(width, height);
        }
        /// <summary>
        /// Initializes the opening filter.
        /// </summary>
        /// <param name="size">Filter size</param>
        public Opening(SizeInt size)
        {
            erosion = new Erosion(size);
            dilatation = new Dilatation(size);
        }
        /// <summary>
        /// Gets or sets the filter size.
        /// </summary>
        public SizeInt Size
        {
            get
            {
                return erosion.Size;
            }
            set
            {
                erosion.Size = value;
                dilatation.Size = value;
            }
        }
        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="bmData">Bitmap data</param>
        /// <param name="bmSrc">Bitmap data</param>
        public void Apply(BitmapData bmData, BitmapData bmSrc)
        {
            erosion.Apply(bmSrc, bmData);
            dilatation.Apply(bmData, bmSrc);
        }
        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="Data">Bitmap</param>
        /// <param name="Src">Bitmap</param>
        public void Apply(Bitmap Data, Bitmap Src)
        {
            BitmapData bmData = BitmapFormat.Lock32bpp(Data);
            BitmapData bmSrc = BitmapFormat.Lock32bpp(Src);
            Apply(bmData, bmSrc);
            BitmapFormat.Unlock(Data, bmData);
            BitmapFormat.Unlock(Src, bmSrc);
        }
        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="bmData">Bitmap data</param>
        public void Apply(BitmapData bmData)
        {
            Bitmap Src = (Bitmap)BitmapFormat.Bitmap(bmData).Clone();
            BitmapData bmSrc = BitmapFormat.Lock32bpp(Src);
            Apply(bmData, bmSrc);
            BitmapFormat.Unlock(Src, bmSrc);
            Src.Dispose();
            return;
        }
        /// <summary>
        /// Apply filter.
        /// </summary>
        /// <param name="Data">Bitmap</param>
        public void Apply(Bitmap Data)
        {
            BitmapData bmData = BitmapFormat.Lock32bpp(Data);
            Apply(bmData);
            BitmapFormat.Unlock(Data, bmData);
            return;
        }
        #endregion
    }
}
