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
    public class RegistrationController : ControllerBase
    {
        ProjectContext db = new ProjectContext();
        [HttpGet]
        [Route("ListUserdata")]
        public IActionResult GetUserdata()
        {
            var data = from Registration in db.Registrations
                       select new
                       {
                           Cust_id = Registration.CustId,
                           Cust_Name = Registration.CustName,
                           Cust_DOB = Registration.CustDob,
                           Email = Registration.Email,
                           Phone_No = Registration.PhoneNo,
                           Address = Registration.Address,
                           User_Name = Registration.UserName,
                           Password = Registration.Password,
                           Card_Type = Registration.CardType,
                           BankAccNo = Registration.BankAccNo,
                           IFSC = Registration.Ifsc,
                           Rstatus = Registration.Rstatus
                       };
            return Ok(data);
        }
        [HttpGet]
        [Route("Getuserbyid")]
        public IActionResult GetUserbyid(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id Cannot be null");   //getting a particular department based on id
            }
            //var data = (from dept in db.Depts where dept.Id == id select new { Id = dept.Id, Name = dept.Name, Location = dept.Location }).FirstOrDefault();
            var data = (from Registration in db.Registrations
                        where Registration.CustId == id
                        select new
                        {
                            Cust_id = Registration.CustId,
                            Cust_Name = Registration.CustName,
                            Cust_DOB = Registration.CustDob,
                            Email = Registration.Email,
                            Phone_No = Registration.PhoneNo,
                            Address = Registration.Address,
                            User_Name = Registration.UserName,
                            Password = Registration.Password,
                            Card_Type = Registration.CardType,
                            BankAccNo = Registration.BankAccNo,
                            IFSC = Registration.Ifsc,
                            Rstatus = Registration.Rstatus
                        }).FirstOrDefault();
            if (data == null)
            {
                return NotFound($"User with id no {id} not present");
            }
            return Ok(data);
        }
        [HttpPost]
        [Route("AddUserdata")]
        public IActionResult AddUserdata(Registration registration)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Registrations.Add(registration);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return BadRequest("Something went wrong");
                }
            }
            return Created("Successfully Registered", registration);
        }
        [HttpPut]
        [Route("ApproveUserdata/{id}")]
        public IActionResult ApproveUserdata(int id, Registration registration)
        {
            if (ModelState.IsValid)
            {
                Registration odata = db.Registrations.Find(id);
                odata.Rstatus = true;
                db.SaveChanges();
                return Ok();
            }
            return BadRequest("Unable to approve the registration");
        }

    }
}
