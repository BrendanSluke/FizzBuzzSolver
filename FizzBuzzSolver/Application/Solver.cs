using FizzBuzzSolver.Data.Models;

namespace FizzBuzzSolver.Application
{
    public static class Solver
    {
        public static string[] Solve(SolveRequest solveRequest)
        {
            string[] outputValues = new string[solveRequest.MaxNumber];

            // Sort the divisor keys (numbers) in ascending order
            var divisorsOrderedAscending = solveRequest.Divisors.OrderBy(divisor => divisor.Key);

            for (int i = 1; i < solveRequest.MaxNumber + 1; i++)
            {
                var atleastOneValidDivisorFound = false;

                foreach (var divisor in divisorsOrderedAscending)
                {
                    if (i % divisor.Key == 0)
                    {
                        outputValues[i-1] += divisor.Value;

                        if(!atleastOneValidDivisorFound) atleastOneValidDivisorFound = true;
                    }
                }

                // If no valid divisors were found, just print the number
                if (!atleastOneValidDivisorFound) outputValues[i - 1] = i.ToString();     
            }

            return outputValues;
        }

        public static string FormatResultWithNewLines(string[] results)
        {
            var outputWithNewLines = string.Empty;

            for (int i = 0; i < results.Length; i++)
            {
                outputWithNewLines += results[i];

                // Add a new line character after every result, except for the final result
                if (i != results.Length - 1) outputWithNewLines += "\n";
            }

            return outputWithNewLines;
        }
    }
}