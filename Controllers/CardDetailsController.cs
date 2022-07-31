using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardDetailsController : ControllerBase
    {
        ProjectContext db = new ProjectContext();
        [HttpPost]
        [Route("AddCardDetails")]
        public IActionResult AddCardDetails(CardDetail carddet)
        {
               if(ModelState.IsValid)
            {
                try
                {
                    db.CardDetails.Add(carddet);
                    db.SaveChanges();
                }
                catch(Exception)
                {
                    return BadRequest("Something went wrong");
                }
            }
            return Created("Record added succesfully",carddet);

        }
        [HttpGet]
        [Route("GetCardDetails/{id}")]
        public IActionResult GetCardDetails(int id, Registration registration)
        {
           if(ModelState.IsValid)
            {
                var data = from CardDetail in db.CardDetails
                           where CardDetail.CustId == id
                           select new
                           {
                               CardNo = CardDetail.CardNo,
                               CustId = CardDetail.CustId,
                               ValidTill = CardDetail.ValidTill,
                               CardStatus = CardDetail.CardStatus,
                               TotalCredit = CardDetail.TotalCredit,
                               RemainingCredit = CardDetail.RemainingCredit
                           };
                return Ok(data);
            }
            return BadRequest("Something went wrong");
    }

    }
}
