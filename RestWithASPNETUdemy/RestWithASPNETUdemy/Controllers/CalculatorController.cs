using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/values/sum/5/5
        [HttpGet("sum/{firstNumber}/{secundNumber}")]
        public IActionResult Sum( string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConverToDecimal(firstNumber) + ConverToDecimal(secundNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/subtration/5/5
        [HttpGet("subtraction/{firstNumber}/{secundNumber}")]
        public IActionResult Subtraction(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var subtraction = ConverToDecimal(firstNumber) - ConverToDecimal(secundNumber);
                return Ok(subtraction.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/subtration/5/5
        [HttpGet("division/{firstNumber}/{secundNumber}")]
        public IActionResult Division(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var division = ConverToDecimal(firstNumber) / ConverToDecimal(secundNumber);
                return Ok(division.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secundNumber}")]
        public IActionResult Multiplication(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var multiplication = ConverToDecimal(firstNumber) * ConverToDecimal(secundNumber);
                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/mean/5/5
        [HttpGet("mean/{firstNumber}/{secundNumber}")]
        public IActionResult Mean(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var mean =  ( ConverToDecimal(firstNumber) + ConverToDecimal(secundNumber) ) / 2;
                return Ok(mean.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/square-root/5
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var SquareRoot = Math.Sqrt(ConverToDecimal(number));
                return Ok(SquareRoot.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private double ConverToDecimal(string number)
        {
            if (double.TryParse(number, out double decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string number)
        {
            bool isNumber = Double.TryParse(number,System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double _number);
            return isNumber;
        }
    }
}
