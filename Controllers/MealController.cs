using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiustHostel.Dtos;
using BaiustHostel.Migrations;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class MealController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public MealController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    public IEnumerable<Meal> GetMeal()
	    {
		    return _context.Meals.Include(m => m.FoodMenu.FoodItems).ToList();
	    }

		[HttpPost]
	    public IHttpActionResult UpdateMeal(AddMeal addMeal)
	    {
		    var dbMeal = _context.Meals.Include(m => m.FoodMenu.FoodItems).SingleOrDefault(f => f.Id == addMeal.MealId);

		    if (dbMeal == null) return BadRequest("No meal found in this id");

		    var foodMenu = _context.FoodMenus.Include(f => f.FoodItems)
			    .SingleOrDefault(f => f.Id == addMeal.FoodMenuId);

		    if (foodMenu == null)
			    return BadRequest("No food menu in the given id");

		    var studentMeals = _context.StudentMeals.Where(s => s.MealId == addMeal.MealId);
		    foreach (var studentMeal in studentMeals)
		    {
			    _context.StudentMeals.Remove(studentMeal);
		    }

		    dbMeal.FoodMenu = foodMenu;
		    dbMeal.FullPrice = foodMenu.FullPrice;

		    _context.SaveChanges();

		    return Ok("ok");
	    }

		[Route("api/meal/studentMeal/")]
		[HttpPost]
		public IHttpActionResult AddMeal(StudentMeal studentMeal)
		{
			var studentInDb = _context.Students.SingleOrDefault(s => s.Id == studentMeal.StudentId);
			var foodMenu = _context.Meals.Include(f => f.FoodMenu)
				.SingleOrDefault(m => m.Id == studentMeal.MealId);

			if (studentInDb == null || foodMenu == null) return BadRequest("No student is found");

			studentInDb.DeuAmount = studentInDb.DeuAmount + foodMenu.FoodMenu.FullPrice;

			studentMeal.AssignToken();

			_context.StudentMeals.Add(studentMeal);

			_context.SaveChanges();
			return Ok(studentMeal);
		}

		[Route("api/meal/price/")]
		[HttpPost]
		public IHttpActionResult MealPrice()
		{
			var price = _context.Meals.Select(m => m.FoodMenu.FullPrice).Sum();
			return Ok(price);
		}

		[Route("api/meal/CancelStudentMeal/")]
		[HttpPost]
		public IHttpActionResult RemoveMeal(StudentMeal studentMeal)
		{


			var studentInDb = _context.Students.SingleOrDefault(s => s.Id == studentMeal.StudentId);

			var foodMenu = _context.Meals.Include(f => f.FoodMenu)
				.SingleOrDefault(m => m.Id == studentMeal.MealId);

			var studentMealInDb = _context.StudentMeals.SingleOrDefault(sm =>
				sm.MealId == studentMeal.MealId && sm.StudentId == studentMeal.StudentId);

			if (studentInDb == null || foodMenu == null || studentMealInDb == null) return BadRequest("No student is found");


			studentInDb.DeuAmount -= foodMenu.FoodMenu.FullPrice;

			_context.StudentMeals.Remove(studentMealInDb);


			_context.SaveChanges();
			return Ok(studentMeal);
		}



		[Route("api/meal/taken/")]
		[HttpGet]
		public IEnumerable<StudentMeal> Taken(int id)
		{
			return _context.StudentMeals.Where(sm => sm.StudentId == id).ToList();
		}


		[Route("api/meal/extra")]
		[HttpPost]
		public IHttpActionResult ExtraMeals(ExtraMeal extraMeal)
		{
			var meal = _context.Meals.SingleOrDefault(m => m.Id == extraMeal.MealId);
			if (meal == null || extraMeal.Numbers == 0)
				return BadRequest("no meal at given id");

			var extra = _context.ExtraMeals.SingleOrDefault(em => em.MealId == extraMeal.MealId);

			if (extra != null)
				_context.ExtraMeals.Remove(extra);

			extraMeal.TotalAmount = meal.FullPrice * extraMeal.Numbers;

			_context.ExtraMeals.Add(extraMeal);
			_context.SaveChanges();
			return Ok(extraMeal);
		}

		[Route("api/meal/meals")]
		[HttpGet]
		public IHttpActionResult TotalMeals()
		{
			var arr = new List<int>();
			var bMeal = _context.StudentMeals.Count(s => s.MealId == 3);
			var lMeal = _context.StudentMeals.Count(s => s.MealId == 4);
			var dMeal = _context.StudentMeals.Count(s => s.MealId == 5);
			arr.Add(bMeal);
			arr.Add(lMeal);
			arr.Add(dMeal);
			return Ok(arr);
		}

		[Route("api/mealTokens")]
		[HttpGet]
		public IHttpActionResult GetTokens()
		{
			return Ok(_context.StudentMeals.Include(s => s.Student)
				.Select(s => new { StudentName = s.Student.Name, StudentId = s.Student.Roll, mealId = s.Meal.Name, token = s.MealToken })
				.OrderByDescending(s => s.StudentId)
				.ToList())
				;
		}

		

    }
}
