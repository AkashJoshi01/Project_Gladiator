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
    public class TransactionController : ControllerBase
    {
        ProjectContext db = new ProjectContext();
        [HttpPut]
        [Route("BalanceamoutCalculator/{id}")]
        public IActionResult BalanceAmountCalculator(int id,Transaction transaction)
        {
            //transaction.ProductId = id;
            //ProductDetail productdetails;

            if (ModelState.IsValid)
            {
                int pid = 0;
                Transaction odata = db.Transactions.Find(id);
                pid = odata.ProductId;
                ProductDetail olddata = db.ProductDetails.Find(pid);
                odata.BalanceAmt = olddata.ProductPrice - odata.PaidAmt;
                db.SaveChanges();
                return Ok();
            }
            return BadRequest("Something went wrong");

        }

       [HttpPut]
       [Route("EmiCalculator/{id}")]
       public IActionResult EMICalculator(int id,Transaction transaction)
        {
           if(ModelState.IsValid)
            {
                Transaction odata = db.Transactions.Find(id);
                if(odata.Tenure==0)
                {
                    odata.Emi = 0;
                }
                else
                {
                    odata.Emi = (odata.BalanceAmt) / (odata.Tenure);
                }
                db.SaveChanges();
                return Ok();
            }
            return BadRequest("Something went wrong");
        }

        
       
    }
}
