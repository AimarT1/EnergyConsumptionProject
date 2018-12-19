namespace ECP.API.Controllers
{
    using System;
    using System.Collections.Generic;

    using ECP.API.Business;
    using ECP.API.Models;

    using Microsoft.AspNetCore.Mvc;

    public class TestController : Controller
    {
        [HttpGet]
        [Route("api/test")]
        public IActionResult GetTest(DateTime startDate, DateTime endDate, string grouping)
        {
            bool isValid = ConsumptionRequestValidator.Validate(startDate, endDate, grouping);
            if (!isValid) return this.BadRequest();


            if (grouping.Equals("day"))
            {
                return Ok(new List<ConsumptionModel>
                              {
                                  new ConsumptionModel { Period = "04.01.2018", Amount = 7 },
                                  new ConsumptionModel { Period = "05.01.2018", Amount = 8 },
                                  new ConsumptionModel { Period = "06.01.2018", Amount = 9 }
                              });
            }
            else if (grouping.Equals("week"))
            {
                return Ok(new List<ConsumptionModel>
                              {
                                  new ConsumptionModel { Period = "01.01.2018 - 07.01.2018", Amount = 57 },
                                  new ConsumptionModel { Period = "08.01.2018 - 14.01.2018", Amount = 68 },
                              });
            }
            else if (grouping.Equals("month"))
            {
                return Ok(new List<ConsumptionModel>
                              {
                                  new ConsumptionModel { Period = "January 2018", Amount = 580 },
                                  new ConsumptionModel { Period = "February 2018", Amount = 600 },
                              });
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
