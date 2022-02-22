using FizzBuzzSolver.Data.Models;
using FizzBuzzSolver.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzSolver.Tests.Models.API
{
    [TestClass]
    public class SolveRequestTests
    {
        private Divisor[] stubDivisors = new Divisor[2]
        {
            new Divisor(2, "Fizz"),
            new Divisor(3, "Buzz")
        };

        private int stubMaxNumber = 10;

        [TestMethod]
        public void Validate_Request_Should_Return_False_For_Divisor_Count_Of_Zero()
        {
            // Build empty divisors list
            var divisors = new Divisor[0];

            var solveRequest = new SolveRequest(5, divisors);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }

        [TestMethod]
        public void Validate_Request_Should_Return_False_For_MaxNumber_Equal_To_Zero()
        {
            var solveRequest = new SolveRequest(0, stubDivisors);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }

        [TestMethod]
        public void Validate_Request_Should_Return_False_For_MaxNumber_Less_Than_Zero()
        {
            var solveRequest = new SolveRequest(-1, stubDivisors);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }

        [TestMethod]
        public void Validate_Request_Should_Return_False_For_Divisors_Collection_With_Duplicate_Keys()
        {
            var divisors = new Divisor[3]
            {
                new Divisor(2, "Fizz"),
                new Divisor(3, "Buzz"),
                new Divisor(3, "Foo")
            };

            var solveRequest = new SolveRequest(stubMaxNumber, divisors);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }
    }
}
