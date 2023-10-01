using ActronCodingChallange.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActronCodingChallange.Controllers
{
    [Route("api/v0")]
    [ApiController]
    public class MaxNumberController : Controller
    {
        private readonly IFindMaxNumber _findMaxNumber;

        public MaxNumberController(IFindMaxNumber findMaxNumber)
        {
            _findMaxNumber = findMaxNumber;
        }

        [HttpPost("formLargestInt")]
        public IActionResult formLargestInt([FromBody] List<int> input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Input is not valid.");
                }

                string result = _findMaxNumber.FindMaxNumber(input);

                return Ok(new { output = result });
            }
            catch 
            {
                return StatusCode(500, new { error = "An error occurred while processing the request." });
            }
        }
    }
}