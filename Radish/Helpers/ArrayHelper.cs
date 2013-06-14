using System;

namespace Radish.Helpers
{
    public class ArrayHelper
    {
        public static bool Equals<T>(T[] array1, T[] array2)
        {
            if (array1 == null || array2 == null)
                return false;
            if (array1.LongLength != array2.LongLength)
                return false;
            for (int i = 0; i < array1.Length; i++)
            {
                if (!Equals(array1[i], array2[i]))
                    return false;
            }
            return true;
        }
    }
}
