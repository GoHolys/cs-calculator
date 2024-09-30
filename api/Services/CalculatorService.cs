using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;

namespace api.Services
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Calculate(decimal x, decimal y, string indicator)
        {
            return indicator switch
            {
                "+" => x + y,
                "-" => x - y,
                "*" => x * y,
                "/" => y != 0 ? x / y : throw new DivideByZeroException("Cannot divide by zero"),
                _ => throw new ArgumentException("Invalid operator")
            };
        }
    }
}