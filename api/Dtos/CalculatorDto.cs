using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CalculatorDto
    {
        public class CalculationRequest
        {
            [Required]
            public decimal X { get; set; }

            [Required]
            public decimal Y { get; set; }

            [Required]
            [RegularExpression(@"^[+\-*/]$", ErrorMessage = "Indicator must be +, -, *, or /")]
            public required string Indicator { get; set; }
        }
    }
}