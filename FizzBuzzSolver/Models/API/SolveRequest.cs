using FizzBuzzSolver.Models;
using FizzBuzzSolver.Models.API;

namespace FizzBuzzSolver.Data.Models
{
    public class SolveRequest : IFizzBuzzSolverRequest
    {
        public SolveRequest(long maxNumber, Divisor[] divisors)
        {
            MaxNumber = maxNumber;
            Divisors = divisors;
        }

        public long MaxNumber { get; private set; }

        public Divisor[] Divisors { get; set; }

        public (bool, string) ValidateRequest()
        {
            if (Divisors.Count() == 0)
            {
                return (false, "Your request must include atleast one divisor.");
            }

            if (MaxNumber <= 0)
            {
                return (false, "MaxNumber must be greater than or equal to zero.");
            }

            var checkForDuplicateDivisorKeys = CheckForDuplicateDivisorKeys();
            if (!checkForDuplicateDivisorKeys.Item1)
            {
                return (false, checkForDuplicateDivisorKeys.Item2);
            }

            return (true, String.Empty);
        }

        private (bool, string) CheckForDuplicateDivisorKeys()
        {
            var uniqueDivisorKeys = new HashSet<long>();
            var duplicateKeys = Divisors.Where(divisor => !uniqueDivisorKeys.Add(divisor.DivisorNumericValue)).Select(divisor => divisor.DivisorNumericValue).ToList();
            var duplicateKeysCount = duplicateKeys.Count();

            if (duplicateKeysCount != 0)
            {
                var duplicateKeysCSV = string.Empty;

                for (int i = 0; i < duplicateKeysCount; i++)
                {
                    duplicateKeysCSV += duplicateKeys[i];

                    // Add a comma after every duplicate key, except for the final duplicate key
                    if (i != duplicateKeysCount - 1) duplicateKeysCSV += ",";
                }

                // Build an invalid request message that includes the number of total duplicate divisors, and the number values for each duplicate
                var duplicateKeysMessage = $"Your request contained duplicate divisor keys, all divisors must have a unique numerical key. Total Duplicate Divisor Keys: {duplicateKeysCount} - Duplicate Divisor Key Numeric Values: {duplicateKeysCSV}";
                return (false, duplicateKeysMessage);
            }

            // No duplicate keys found, request is valid
            return (true, String.Empty);
        }
    }
}
