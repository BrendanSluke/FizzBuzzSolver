namespace FizzBuzzSolver.Models.API
{
    public interface IFizzBuzzSolverRequest
    {
        /// <summary>
        /// All incoming requests to the Fizz Buzz Solver API should implement this interface to handle validating incoming requests.
        /// </summary>
        /// <returns>A tuple where the first item indicates if the request is valid or not, and a string value describing why a request may have failed.</returns>
        public (bool, string) ValidateRequest();
    }
}
