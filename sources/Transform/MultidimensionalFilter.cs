﻿using UMapx.Core;

namespace UMapx.Transform
{
    /// <summary>
    /// Defines the multidimensional filter.
    /// </summary>
    public class MultidimensionalFilter
    {
        #region Initialize
        /// <summary>
        /// Initializes the multidimensional filter.
        /// </summary>
        /// <param name="filter">IFilter</param>
        public MultidimensionalFilter(IFilter filter)
        {
            Filter = filter;
        }
        /// <summary>
        /// Gets or sets transform.
        /// </summary>
        public IFilter Filter { get; set; }
        #endregion

        #region Transform methods
        /// <summary>
        /// Forward multidimensional filter.
        /// </summary>
        /// <param name="A">Jagged array</param>
        /// <returns>Jagged array</returns>
        public void Apply(params double[][] A)
        {
            int count = A.Length;

            for (int i = 0; i < count; i++)
            {
                Filter.Apply(A[i]);
            }
        }
        /// <summary>
        /// Forward multidimensional filter.
        /// </summary>
        /// <param name="A">Jagged matrix</param>
        /// <returns>Jagged matrix</returns>
        public void Apply(params double[][,] A)
        {
            int count = A.Length;

            for (int i = 0; i < count; i++)
            {
                Filter.Apply(A[i]);
            }
        }
        /// <summary>
        /// Forward multidimensional filter.
        /// </summary>
        /// <param name="A">Jagged array</param>
        /// <returns>Jagged array</returns>
        public void Apply(params Complex[][] A)
        {
            int count = A.Length;

            for (int i = 0; i < count; i++)
            {
                Filter.Apply(A[i]);
            }
        }
        /// <summary>
        /// Forward multidimensional filter.
        /// </summary>
        /// <param name="A">Jagged matrix</param>
        /// <returns>Jagged matrix</returns>
        public void Apply(params Complex[][,] A)
        {
            int count = A.Length;

            for (int i = 0; i < count; i++)
            {
                Filter.Apply(A[i]);
            }
        }
        #endregion
    }
}
