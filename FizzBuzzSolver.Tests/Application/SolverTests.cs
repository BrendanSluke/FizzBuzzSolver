using FizzBuzzSolver.Application;
using FizzBuzzSolver.Data.Models;
using FizzBuzzSolver.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FizzBuzzSolver.Tests.Application
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void Solve_Success_Basic_Fizz_Buzz()
        {

            var divisors = new Divisor[2]
            {
                new Divisor(3, "Fizz"),
                new Divisor(5, "Buzz")
            };

            var solveRequest = new SolveRequest(5, divisors);

            var result = Solver.Solve(solveRequest);

            var expectedResult = new string[5]
            {
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz"
            };

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Solve_Success_Basic_Fizz_Buzz_Divisors_Unsorted()
        {
            // Create a divisors list where the numbers are not sorted in ascending order
            var divisors = new Divisor[2]
            {
                new Divisor(5, "Buzz"),
                new Divisor(3, "Fizz")
            };

            var solveRequest = new SolveRequest(5, divisors);

            var result = Solver.Solve(solveRequest);

            var expectedResult = new string[5]
            {
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz"
            };

            CollectionAssert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void Solve_Success_2_Divisors_For_A_Single_Number()
        {
            var divisors = new Divisor[2]
            {
                new Divisor(2, "Fizz"),
                new Divisor(3, "Buzz")
            };

            var solveRequest = new SolveRequest(8, divisors);

            var result = Solver.Solve(solveRequest);

            var expectedResult = new string[8]
            {
                "1",
                "Fizz",
                "Buzz",
                "Fizz",
                "5",
                "FizzBuzz",
                "7",
                "Fizz"
            };

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Solve_FizzBuzz_Success_3_Divisors_For_A_Single_Number()
        {
            var divisors = new Divisor[3]
            {
                new Divisor(2, "Fizz"),
                new Divisor(3, "Buzz"),
                new Divisor(4, "Foo")
            };

            var solveRequest = new SolveRequest(12, divisors);

            var result = Solver.Solve(solveRequest);

            var expectedResult = new string[12]
            {
                "1",
                "Fizz",
                "Buzz",
                "FizzFoo",
                "5",
                "FizzBuzz",
                "7",
                "FizzFoo",
                "Buzz",
                "Fizz",
                "11",
                "FizzBuzzFoo"
            };

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FormatResultWithNewLines_Should_Have_One_Less_New_Line_Than_The_Total_Strings_In_Preformatted_Array()
        {
            var testStringArray = new string[3] { "test1", "test2", "test3"};

            var formattedResult = Solver.FormatResultWithNewLines(testStringArray);

            var formattedResultCharArray = formattedResult.ToCharArray();

            var newLineCharCount = 0;

            foreach (var result in formattedResultCharArray)
            {
                if (result == '\n')
                {
                    newLineCharCount++;
                }
            }

            Assert.AreEqual(testStringArray.Length - 1, newLineCharCount);
        }

        [TestMethod]
        public void FormatResultWithNewLines_Should_Not_End_With_A_New_Line_Char()
        {
            var testStringArray = new string[3] { "test1", "test2", "test3" };

            var formattedResult = Solver.FormatResultWithNewLines(testStringArray);

            var formattedResultCharArray = formattedResult.ToCharArray();

            Assert.AreNotEqual('\n', formattedResultCharArray[testStringArray.Length -1]);
        }
    }
}
