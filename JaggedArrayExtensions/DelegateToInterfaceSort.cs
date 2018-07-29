using System;
using System.Collections.Generic;

namespace JaggedArrayExtensions
{
    /// <summary>
    /// Class of bubble sort method for jagged array.
    /// Delegate -> Interface.
    /// </summary>
    public static class DelegateToInterfaceSort
    {
        #region Sorting method

        /// <summary>
        /// Bubble sort method with specific ordering variants.
        /// Delegate -> Interface realisation.
        /// </summary>
        /// <param name="source">Source jagged array.</param>
        /// <param name="compare">Comparison delegate which represents the rule according to which the ordering will be carried out.</param>
        /// <exception cref="ArgumentNullException">Thrown when jagged array or comparison delegate is null.</exception>
        /// <exception cref="ArgumentException">Thrown when jagged array is empty.</exception>
        public static void BubbleSort(this int[][] source, Comparison<int[]> compare)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can not be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"{nameof(source)} can not be empty.");
            }

            if (compare == null)
            {
                throw new ArgumentNullException($"{nameof(compare)} can not be null.");
            }

            source.InterfaceSort(Comparer<int[]>.Create(compare));
        }

        #endregion

        #region Private methods

        private static void InterfaceSort(this int[][] source, IComparer<int[]> comparer)
        {
            for (int i = 0; i < source.Length; i++)
            {
                bool flag = false;

                for (int j = 0; j < source.Length - 1; j++)
                {
                    if (comparer.Compare(source[j], source[j + 1]) > 0)
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
