using System;
using System.Diagnostics;

namespace NewInCSharp7.RefReturns
{
    public class RefReturns
    {
        public void RefReturnsDemo()
        {
            int[,] matrix = CreateMatrix(10, 10);

            Debug.WriteLine(matrix[3,2]);

            // A method returning a ref can be called like this:
            ref var item = ref FindElement(matrix, i => i == 32);
            item = 100;

            Debug.WriteLine(matrix[3, 2]);
        }

        // A method returning a ref. This method returns a reference to a certain item in a matrix.
        // The caller will be able to modify that item directly.
        public ref int FindElement(int[,] matrix, Predicate<int> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j]))
                    {
                        return ref matrix[i, j];
                    }
                }
            }

            throw new InvalidOperationException("Element not found");
        }

        private int[,] CreateMatrix(int length0, int length1)
        {
            int[,] matrix = new int[length0, length1];
            int value = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }
    }
}

