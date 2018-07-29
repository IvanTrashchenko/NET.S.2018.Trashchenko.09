using System;
using System.Collections.Generic;

namespace JaggedArrayExtensions
{
    /// <summary>
    /// Class of bubble sort method for jagged array.
    /// Interface -> Delegate.
    /// </summary>
    public static class InterfaceToDelegateSort
    {
        #region Sorting method

        /// <summary>
        /// Bubble sort method with specific ordering variants.
        /// Interface -> Delegate realisation.
        /// </summary>
        /// <param name="source">Source jagged array.</param>
        /// <param name="comparer">Comparer according to which the ordering will be carried out.</param>
        /// <exception cref="ArgumentNullException">Thrown when jagged array or comparer is null.</exception>
        /// <exception cref="ArgumentException">Thrown when jagged array is empty.</exception>
        public static void BubbleSort(this int[][] source, IComparer<int[]> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"{nameof(source)} can not be empty.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can not be null.");
            }

            source.DelegateSort(comparer.Compare);
        }

        #endregion

        #region Private methods

        private static void DelegateSort(this int[][] source, Comparison<int[]> compare)
        {
            for (int i = 0; i < source.Length; i++)
            {
                bool flag = false;

                for (int j = 0; j < source.Length - 1; j++)
                {
                    if (compare(source[j], source[j + 1]) > 0)
                    {
                        Swap(ref source[j], ref source[j + 1]);
                        flag = true;
                    }
                }

                if (!flag)
                {
                    break;
                }
            }
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        #endregion
    }
}
