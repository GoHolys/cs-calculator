using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface ICalculatorService
    {
        decimal Calculate(decimal x, decimal y, string indicator);
    }
}