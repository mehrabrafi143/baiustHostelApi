using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class AccountInfoController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public AccountInfoController()
	    {
		    _context = new ApplicationDbContext();
	    }

		[HttpGet]
		[Route("api/totalMealPrice")]
	    public IHttpActionResult GetTotalMealPrice()
	    {
		   List<float> arr = new List<float>();
		   var extraMealPrice =  _context.ExtraMeals.Select(em => em.TotalAmount).Sum();
		   var studentsMealPrice = _context.StudentMeals.Select(sm => sm.Meal.FoodMenu.FullPrice).Sum();
			arr.Add(studentsMealPrice);
			arr.Add(extraMealPrice);
			return Ok();
	    }

	    [HttpGet]
		[Route("api/totalDeu")]
	    public IHttpActionResult GetTotalDeu()
	    {
		    return Ok(_context.Students.Select(s => s.DeuAmount).Sum());
	    }

	    [HttpGet]
		[Route("api/totalPaid")]
	    public IHttpActionResult GetPaid()
	    {
		    return Ok(_context.Students.Select(s => s.PaidAmount).Sum());
	    }
    }
}
