using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        //PathParam
        //https://localhost:44300/calculator/sum/2/3

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }                

            return BadRequest("Invalid Input");
        }
        
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public ActionResult multiplicacao(string firstNumber, string secondNumber)
        {
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public ActionResult subtracao(string firstNumber, string secondNumber)
        {
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public ActionResult divisao(string firstNumber, string secondNumber)
        {
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public ActionResult media(string firstNumber, string secondNumber)
        {
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(media.ToString());
            }

            return BadRequest("Invalid Input");
        }


        [HttpGet("sqrt/{strNumber}")]
        public ActionResult sqrt(string strNumber)
        {
            {
                var sq = Math.Sqrt(ConvertToDouble(strNumber));

                return Ok(sq.ToString());
            }

            return BadRequest("Invalid Input");
        }


        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private double ConvertToDouble(string strNumber)
        {
            double doubleValues;

            if (double.TryParse(strNumber, out doubleValues))
            {
                return doubleValues;
            }

            return 0;
        }


        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(
                        strNumber,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.NumberFormatInfo.InvariantInfo,
                        out number);

            return isNumber;
        }
    }
}
