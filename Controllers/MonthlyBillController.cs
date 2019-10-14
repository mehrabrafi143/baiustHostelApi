using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class MonthlyBillController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public MonthlyBillController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    public IHttpActionResult AddBill(MonthlyBill monthlyBill)
	    {
		    if (monthlyBill == null) return BadRequest("null values");

		    var bill = _context.MonthlyBills.SingleOrDefault(m => m.Id == 1);

			if(bill == null)
			{
				_context.MonthlyBills.Add(monthlyBill);
			}
			else
			{
				bill.RoomBill = monthlyBill.RoomBill;
				bill.ServicePrice = monthlyBill.ServicePrice;
			}

			_context.SaveChanges();
			return Ok(monthlyBill);
	    }

		[HttpPost]
		[Route("api/addmonthlyBill")]
	    public IHttpActionResult AddMonthlyBill()
	    {
		    var students = _context.Students.ToList();
		    var bill = _context.MonthlyBills.SingleOrDefault(b => b.Id == 1);
		    if (bill == null) return BadRequest("bill isn't set");

		    var totalBill = bill.RoomBill + bill.ServicePrice;
		    foreach (var student in students)
		    {
			    student.DeuAmount += totalBill;
		    }

		    _context.SaveChanges();
		    return Ok("added");
	    }
    }
}
