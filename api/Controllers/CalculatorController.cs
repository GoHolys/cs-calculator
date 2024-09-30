using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static api.Dtos.CalculatorDto;

namespace api.Controllers
{
    [ApiController]
    [Route("math")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost]
        public IActionResult PostCalculation([FromBody] CalculationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _calculatorService.Calculate(request.X, request.Y, request.Indicator);
                return Ok(result);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Cannot divide by zero");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpGet]
        public IActionResult GetCalculation([FromQuery] CalculationRequest request)
        {  
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _calculatorService.Calculate(request.X, request.Y, request.Indicator);
                return Ok(result);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Cannot divide by zero");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpGet("{x}/{y}/{indicator}")]
        public IActionResult GetCalculationFromPath(decimal x, decimal y, string indicator)
        {
            indicator = Uri.UnescapeDataString(indicator);

            var request = new CalculationRequest { X = x, Y = y, Indicator = indicator };
            if (!TryValidateModel(request))
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _calculatorService.Calculate(request.X, request.Y, request.Indicator);
                return Ok(result);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Cannot divide by zero");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }
    }
}