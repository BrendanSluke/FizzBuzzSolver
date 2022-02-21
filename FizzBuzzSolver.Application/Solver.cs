using FizzBuzzSolver.Data.Models;

namespace FizzBuzzSolver.Application
{
    public static class Solver
    {
        public static string Solve(SolveRequest solveRequest)
        {
            string output = string.Empty;

            for (int i = 1; i < solveRequest.MaxNumber; i++)
            {
                var atleastOneValidDivisorFound = false;

                foreach (var divisor in solveRequest.Divisors)
                {
                    if (i % divisor.Key == 0)
                    {
                        output += divisor.Value;

                        if(!atleastOneValidDivisorFound) atleastOneValidDivisorFound = true;
                    }
                }


                // If no valid divisors were found, just print the number
                if (!atleastOneValidDivisorFound) output += i.ToString();

                // TODO: Add new line
            }

            return output;
        }
    }
}