﻿using System;
using System.Drawing;

namespace UMapx.Visualization
{
    /// <summary>
    /// Defines paint data.
    /// </summary>
    [Serializable]
    public class PaintData
    {
        #region Class components
        /// <summary>
        /// Initializes paint data.
        /// </summary>
        public PaintData() { }
        /// <summary>
        /// Gets or sets title.
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets rectangle.
        /// </summary>
        public Rectangle Rectangle { get; set; } = new Rectangle();
        /// <summary>
        /// Gets or sets labels.
        /// </summary>
        public string[] Labels { get; set; } = { };
        /// <summary>
        /// Gets or sets points.
        /// </summary>
        public Point[] Points { get; set; } = { };
        #endregion
    }
}
