using FizzBuzzSolver.Application;
using FizzBuzzSolver.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FizzBuzzSolver.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolveController : ControllerBase
    {
        // GET: api/<SolveController>
        [HttpPost]
        public IActionResult Post([FromBody] SolveRequest solveRequest)
        {
            // Validate the incoming request
            var validateRequestResult = solveRequest.ValidateRequest();
            if (!validateRequestResult.Item1)
            {
                return new BadRequestObjectResult(validateRequestResult.Item2);
            }

            // Perform the FizzBuzz Solver for the given request
            var result = Solver.Solve(solveRequest);
            
            // Format the Output to Have New Lines Added for each string value
            var formattedResult = Solver.FormatResultWithNewLines(result);

            return new OkObjectResult(formattedResult);
        }
    }
}
