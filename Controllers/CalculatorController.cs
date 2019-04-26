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
            try
            {
                calculator.Add(value);
            }
            catch (Exception e)
            {
                return "Es ist ein unerwarteter Fehler aufgetreten, ihr PC wird nun heruntergefahren.";
            }
            return "" + calculator.Add(value);


        }

    }
}
