using System;

namespace Lab_9_stt // Make sure this namespace matches your project name
{
    // This class handles all the calculation logic.
    internal class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
                {
            return a* b;
        }

        public double Divide(double a, double b)
        {
            // A good practice check to prevent a crash
            if (b == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
                return 0; // Return 0 or handle the error as appropriate
            }
            return a / b;
        }
    }
}