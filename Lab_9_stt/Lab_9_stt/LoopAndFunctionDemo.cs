using System;
using System.Collections.Generic; // We need this to use List<>

namespace Lab_9_stt
{
    internal class LoopAndFunctionDemo
    {
        // 1. 'for' loop to print 1 to 10
        public void RunForLoop()
        {
            Console.WriteLine("--- Running 'for' loop ---");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        // 2. 'foreach' loop to print 1 to 10
        public void RunForEachLoop()
        {
            Console.WriteLine("--- Running 'foreach' loop ---");
            // A 'foreach' loop needs a collection to loop over. We'll create a List.
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }

        // 3. 'do-while' loop for user input
        public void RunDoWhileLoop()
        {
            Console.WriteLine("--- Running 'do-while' loop ---");
            string userInput; // Declare the variable outside the loop

            do
            {
                Console.Write("Type 'exit' to stop: ");

                // --- THIS IS THE FIX ---
                // We use "?." and "??" to safely handle null input
                // and convert to lowercase.
                userInput = Console.ReadLine()?.ToLower() ?? "";
            }
            while (userInput != "exit"); // Loop as long as the input is NOT "exit"

            Console.WriteLine("Exited loop.");
        }

        // 4. 'static' function for factorial
        public static long CalculateFactorial(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
                return -1; // Error code
            }
            if (n == 0)
            {
                return 1; // Factorial of 0 is 1
            }

            long result = 1;
            // Use a loop to multiply 1 * 2 * 3 * ... * n
            for (int i = 1; i <= n; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
}