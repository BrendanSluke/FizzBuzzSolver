using FizzBuzzSolver.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FizzBuzzSolver.Tests.Models.API
{
    [TestClass]
    public class SolveRequestTests
    {
        private List<KeyValuePair<long, string>> stubDivisorsList = 
            new List<KeyValuePair<long, string>>()
                {
                    new KeyValuePair<long, string>(2, "Fizz"),
                    new KeyValuePair<long, string>(3, "Buzz")
                };

        private int stubMaxNumber = 10;


        [TestMethod]
        public void Validate_Request_Should_Return_False_For_Divisor_Count_Of_Zero()
        {
            // Build empty divisors list
            var divisors = new List<KeyValuePair<long, string>>();

            var solveRequest = new SolveRequest(5, divisors);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }

        [TestMethod]
        public void Validate_Request_Should_Return_False_For_MaxNumber_Equal_To_Zero()
        {
            var solveRequest = new SolveRequest(0, stubDivisorsList);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }

        [TestMethod]
        public void Validate_Request_Should_Return_False_For_MaxNumber_Less_Than_Zero()
        {
            var solveRequest = new SolveRequest(-1, stubDivisorsList);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }

        [TestMethod]
        public void Validate_Request_Should_Return_False_For_Divisors_Collection_With_Duplicate_Keys()
        {
            var divisors = new List<KeyValuePair<long, string>>()
            {
                new KeyValuePair<long, string>(2, "Fizz"),
                new KeyValuePair<long, string>(3, "Buzz"),
                new KeyValuePair<long, string>(3, "Foo")
            };

            var solveRequest = new SolveRequest(stubMaxNumber, divisors);

            var validationResult = solveRequest.ValidateRequest();

            Assert.AreEqual(false, validationResult.Item1);
        }
    }
}
