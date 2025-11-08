using System;

namespace Lab_9_stt
{
    internal class ArrayDemo
    {
        // --- Helper function to print a 1D array ---
        private void PrintArray(int[] arr)
        {
            // String.Join combines all elements with a ", "
            Console.WriteLine("[ " + String.Join(", ", arr) + " ]");
        }

        // --- Helper function to print a 2D matrix ---
        private void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t"); // \t adds a tab
                }
                Console.WriteLine("]");
            }
        }

        // --- 1. Bubble Sort ---
        private void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            // Outer loop for passes
            for (int i = 0; i < n - 1; i++)
            {
                // Inner loop for comparisons
                for (int j = 0; j < n - i - 1; j++)
                {
                    // If current element is greater than next, swap them
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // Public method to demonstrate Bubble Sort
        public void RunBubbleSortDemo()
        {
            Console.WriteLine("--- 1. Bubble Sort Demo ---");
            int[] numbers = { 5, 1, 4, 2, 8 };
            Console.Write("Original array: ");
            PrintArray(numbers);

            BubbleSort(numbers); // Call our sort logic

            Console.Write("Sorted array:   ");
            PrintArray(numbers);
        }

        // --- 2. 2D to 1D Array Conversion ---
        public void Run2DTo1DDemo()
        {
            Console.WriteLine("\n--- 2. 2D to 1D Conversion Demo ---");
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            Console.WriteLine("Original 2D Array (2x3):");
            PrintMatrix(matrix);

            int rows = matrix.GetLength(0); // 2
            int cols = matrix.GetLength(1); // 3
            int[] rowMajor = new int[rows * cols];
            int[] colMajor = new int[rows * cols];

            // (i) Row-Major Order
            int k = 0; // Index for 1D array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    rowMajor[k] = matrix[i, j];
                    k++;
                }
            }
            Console.Write("Row-Major 1D array: ");
            PrintArray(rowMajor);

            // (ii) Column-Major Order
            k = 0; // Reset index
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    colMajor[k] = matrix[i, j];
                    k++;
                }
            }
            Console.Write("Col-Major 1D array: ");
            PrintArray(colMajor);
        }

        // --- 3. Matrix Multiplication ---
        public void RunMatrixMultiplicationDemo()
        {
            Console.WriteLine("\n--- 3. Matrix Multiplication Demo ---");
            int[,] matrixA = {
                { 1, 2, 3 }, // 2x3
                { 4, 5, 6 }
            };
            int[,] matrixB = {
                { 7, 8 },   // 3x2
                { 9, 10 },
                { 11, 12 }
            };

            Console.WriteLine("Matrix A (2x3):");
            PrintMatrix(matrixA);
            Console.WriteLine("Matrix B (3x2):");
            PrintMatrix(matrixB);

            int rowsA = matrixA.GetLength(0); // 2
            int colsA = matrixA.GetLength(1); // 3
            int rowsB = matrixB.GetLength(0); // 3
            int colsB = matrixB.GetLength(1); // 2

            // Check if multiplication is possible
            if (colsA != rowsB)
            {
                Console.WriteLine("Matrices cannot be multiplied.");
                return;
            }

            // Resultant matrix C will be rowsA x colsB (2x2)
            int[,] matrixC = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    matrixC[i, j] = 0;
                    for (int k = 0; k < colsA; k++) // or k < rowsB
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            Console.WriteLine("Resultant Matrix C (2x2):");
            PrintMatrix(matrixC);
        }
    }
}