namespace FizzBuzzSolver.Models
{
    public class Divisor
    {
        public Divisor(long divisorNumericValue, string? printableOutput)
        {
            DivisorNumericValue = divisorNumericValue;
            PrintableOutput = printableOutput;
        }

        public long DivisorNumericValue { get; private set; }
        public string? PrintableOutput { get; private set; }
    }
}
