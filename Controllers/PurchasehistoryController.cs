using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.models;
using Project_Gladiator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasehistoryController : ControllerBase
    {
        ProjectContext db = new ProjectContext();
       [HttpGet]
       [Route("GetPurchaseHistory/{id}")]
       public IActionResult GetPurchaseHistory(int id,PurchaseHistory purchasehistory)
        {
            if(ModelState.IsValid)
            {
                var data = from PurchaseHistory in db.PurchaseHistories
                           where PurchaseHistory.CustId == id
                           select new
                           {
                               CustId = PurchaseHistory.CustId,
                               ProductId = PurchaseHistory.ProductId,
                               ProductName = PurchaseHistory.ProductName,
                               PaidAmt = PurchaseHistory.PaidAmt,
                               ProductPrice = PurchaseHistory.ProductPrice
                           };
                return Ok(data);
            }
            return BadRequest("Something went wrong");
        }
    }
}
