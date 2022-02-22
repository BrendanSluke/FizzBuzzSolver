using FizzBuzzSolver.Data.Models;

namespace FizzBuzzSolver.Application
{
    public static class Solver
    {
        public static string[] Solve(SolveRequest solveRequest)
        {
            string[] outputValues = new string[solveRequest.MaxNumber];

            // Sort the divisor keys (numbers) in ascending order
            var divisorsOrderedAscending = solveRequest.Divisors.OrderBy(divisor => divisor.DivisorNumericValue);

            for (int i = 0; i < solveRequest.MaxNumber; i++)
            {
                var atleastOneValidDivisorFound = false;
                var currentNumberToEvaluate = i + 1; // The actual number to evaluate is 1 greater than the current index

                foreach (var divisor in divisorsOrderedAscending)
                {
                    if (currentNumberToEvaluate % divisor.DivisorNumericValue == 0)
                    {
                        outputValues[i] += divisor.PrintableOutput;

                        if(!atleastOneValidDivisorFound) atleastOneValidDivisorFound = true;
                    }
                }

                // If no valid divisors were found, just print the number
                if (!atleastOneValidDivisorFound) outputValues[i] = currentNumberToEvaluate.ToString();     
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