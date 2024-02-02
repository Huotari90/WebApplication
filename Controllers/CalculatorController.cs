using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("Add")]
        public IActionResult Add(double num1, double num2)
        {
            return Ok(num1 + num2);
        }

        [HttpGet("Subtract")]
        public IActionResult Subtract(double num1, double num2)
        {
            return Ok(num1 - num2);
        }

        [HttpGet("Multiply")]
        public IActionResult Multiply(double num1, double num2)
        {
            return Ok(num1 * num2);
        }

        [HttpGet("Divide")]
        public IActionResult Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                return BadRequest("Nollalla jakaminen ei ole sallittua.");
            }

            return Ok(num1 / num2);
        }
    }
}
