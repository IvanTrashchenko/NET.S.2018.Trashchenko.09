using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace JaggedArrayExtensions.Tests
{
    [TestFixture]
    public class JaggedArrayExtensionTests
    {
        [Test]
        public void BubbleSortTests_Interface_IncreasingSum_Success()
        {
            int[][] actual = new int[6][];
            actual[0] = new int[3] { 3, 2, -1 };
            actual[1] = null;           
            actual[2] = null;
            actual[3] = new int[3] { 6, 3, int.MaxValue - 9 };
            actual[4] = new int[3] { 5, -32, 41 };
            actual[5] = new int[] { };

            int[][] expected = new int[6][];

            expected[0] = actual[1];
            expected[1] = actual[2];
            expected[2] = actual[5];
            expected[3] = actual[0];
            expected[4] = actual[4];
            expected[5] = actual[3];

            actual.BubbleSort(new RowSumIncreasingComparer());

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSortTests_Delegate_DecreasingMaxElement_Success()
        {
            int[][] actual = new int[6][];
            actual[0] = new int[3] { 3, 2, -1 };
            actual[1] = null;
            actual[2] = null;
            actual[3] = new int[3] { 6, 3, int.MaxValue - 9 };
            actual[4] = new int[3] { 5, -32, 41 };
            actual[5] = new int[] { };

            int[][] expected = new int[6][];

            expected[0] = actual[3];
            expected[1] = actual[4];
            expected[2] = actual[0];
            expected[3] = actual[1];
            expected[4] = actual[2];
            expected[5] = actual[5];

            actual.BubbleSort((x, y) => new RowMaxElementDecreasingComparer().Compare(x, y));

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSortTests_Interface_IncreasingMinElement_Success()
        {
            int[][] actual = new int[6][];
            actual[0] = new int[3] { 3, 2, -1 };
            actual[1] = null;
            actual[2] = null;
            actual[3] = new int[3] { 6, 3, int.MaxValue - 9 };
            actual[4] = new int[3] { 5, -32, 41 };
            actual[5] = new int[] { };

            int[][] expected = new int[6][];

            expected[0] = actual[1];
            expected[1] = actual[2];
            expected[2] = actual[5];
            expected[3] = actual[4];
            expected[4] = actual[0];
            expected[5] = actual[3];

            actual.BubbleSort(new RowMinElementIncreasingComparer());

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSortTests_Source_ThrowArgumentNullException()
        {
            int[][] actual = null;
            Assert.Throws<ArgumentNullException>(() => actual.BubbleSort(new RowSumDecreasingComparer()));
        }

        [Test]
        public void BubbleSortTests_Source_ThrowArgumentException()
        {
            int[][] actual = { };
            Assert.Throws<ArgumentException>(() => actual.BubbleSort(new RowSumDecreasingComparer()));
        }

        [Test]
        public void BubbleSortTests_Comparer_ThrowArgumentNullException()
        {
            int[][] actual = new int[4][];
            actual[0] = new int[3] { 3, 2, -1 };
            actual[1] = new int[3] { 5, 0, 12 };
            actual[2] = new int[2] { 6, 3 };
            actual[3] = new int[3] { 5, -32, 41 };

            IComparer<int[]> comp = null;

            Assert.Throws<ArgumentNullException>(() => actual.BubbleSort(comp));
        }

        [Test]
        public void BubbleSortTests_IncreasingSum_ThrowOverflowException()
        {
            int[][] actual = new int[6][];
            actual[0] = new int[3] { 3, 2, -1 };
            actual[1] = null;
            actual[2] = null;
            actual[3] = new int[3] { 6, 3, int.MaxValue };
            actual[4] = new int[3] { 5, -32, 41 };
            actual[5] = new int[] { };

            Assert.Throws<OverflowException>(() => actual.BubbleSort(new RowSumIncreasingComparer()));
        }
    }

    #region Comparers
    /// <summary>
    /// Static class which contains methods used in comparers. 
    /// </summary>
    public static class ComparerHelper
    {
        /// <summary>
        /// Method for finding sum of elements in the SZ-array.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>Sum of array's elements.</returns>
        public static int FindSum(int[] array)
        {
            int sum = 0;
            checked
            {
                foreach (var item in array)
                {
                    sum += item;
                }
            }
            return sum;
        }

        /// <summary>
        /// Method for finding max element in the SZ-array.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>Max element of the array.</returns>
        public static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Method for finding min element in the SZ-array.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>Min element of the array.</returns>
        public static int FindMin(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }
    }

    /// <summary>
    /// SZ-array increasing comaprer by sum of its elements.
    /// </summary>
    public class RowSumIncreasingComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null || x.Length == 0)
            {
                return -1;
            }

            if (y == null || y.Length == 0)
            {
                return 1;
            }

            if (ComparerHelper.FindSum(x) > ComparerHelper.FindSum(y))
            {
                return 1;
            }

            if (ComparerHelper.FindSum(x) < ComparerHelper.FindSum(y))
            {
                return -1;
            }

            return 0;
        }
    }

    /// <summary>
    /// SZ-array decreasing comaprer by sum of its elements.
    /// </summary>
    public class RowSumDecreasingComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null || x.Length == 0)
            {
                return 1;
            }

            if (y == null || y.Length == 0)
            {
                return -1;
            }

            if (ComparerHelper.FindSum(x) < ComparerHelper.FindSum(y))
            {
                return 1;
            }

            if (ComparerHelper.FindSum(x) > ComparerHelper.FindSum(y))
            {
                return -1;
            }

            return 0;
        }
    }

    /// <summary>
    /// SZ-array increasing comaprer by its max element.
    /// </summary>
    public class RowMaxElementIncreasingComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null || x.Length == 0)
            {
                return -1;
            }

            if (y == null || y.Length == 0)
            {
                return 1;
            }

            if (ComparerHelper.FindMax(x) > ComparerHelper.FindMax(y))
            {
                return 1;
            }

            if (ComparerHelper.FindMax(x) < ComparerHelper.FindMax(y))
            {
                return -1;
            }

            return 0;
        }
    }

    /// <summary>
    /// SZ-array decreasing comaprer by its max element.
    /// </summary>
    public class RowMaxElementDecreasingComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null || x.Length == 0)
            {
                return 1;
            }

            if (y == null || y.Length == 0)
            {
                return -1;
            }

            if (ComparerHelper.FindMax(x) < ComparerHelper.FindMax(y))
            {
                return 1;
            }

            if (ComparerHelper.FindMax(x) > ComparerHelper.FindMax(y))
            {
                return -1;
            }

            return 0;
        }
    }

    /// <summary>
    /// SZ-array increasing comaprer by its min element.
    /// </summary>
    public class RowMinElementIncreasingComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null || x.Length == 0)
            {
                return -1;
            }

            if (y == null || y.Length == 0)
            {
                return 1;
            }

            if (ComparerHelper.FindMin(x) > ComparerHelper.FindMin(y))
            {
                return 1;
            }

            if (ComparerHelper.FindMin(x) < ComparerHelper.FindMin(y))
            {
                return -1;
            }

            return 0;
        }
    }

    /// <summary>
    /// SZ-array decreasing comaprer by its min element.
    /// </summary>
    public class RowMinElementDecreasingComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null || x.Length == 0)
            {
                return 1;
            }

            if (y == null || y.Length == 0)
            {
                return -1;
            }

            if (ComparerHelper.FindMin(x) < ComparerHelper.FindMin(y))
            {
                return 1;
            }

            if (ComparerHelper.FindMin(x) > ComparerHelper.FindMin(y))
            {
                return -1;
            }

            return 0;
        }
    }

    #endregion
}
