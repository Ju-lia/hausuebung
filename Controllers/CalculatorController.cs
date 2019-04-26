using Eventim;
using Microsoft.AspNetCore.Mvc;
using System;

namespace juliasMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // POST api/stringCalculator
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            Calculator calculator = new Calculator();
                calculator.Add(value);
            return "" + calculator.Add(value);
            try
            {
            }
            catch (Exception e)
            {
                return "Es ist ein unerwarteter Fehler aufgetreten, ihr PC wird nun heruntergefahren.";
            }


        }

    }
}
