using System;
using System.Collections.Generic;
using System.Text;

namespace j0n6s.RadixDlt.Primitives
{
    public static class ArrayExtension
    {
        public static void Fill<T>(this T[] array, int start, int end, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (start < 0 || start >= end)
            {
                throw new ArgumentOutOfRangeException("fromIndex");
            }
            if (end >= array.Length)
            {
                throw new ArgumentOutOfRangeException("toIndex");
            }
            for (int i = start; i < end; i++)
            {
                array[i] = value;
            }
        }
    }
}
