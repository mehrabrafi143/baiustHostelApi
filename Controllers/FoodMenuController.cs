using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiustHostel.Dtos;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class FoodMenuController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public FoodMenuController()
	    {
		    _context = new ApplicationDbContext();
	    }

		[HttpPost]
	    public IHttpActionResult Add(FoodMenu foodMenu)
	    {
		    if (foodMenu == null || foodMenu.FoodItemsId.Count == 0)
			    return BadRequest("can't be null");

		    if (foodMenu.Id != 0)
		    {
			    var menuInDb = _context.FoodMenus.Include(f => f.FoodItems).SingleOrDefault(m => m.Id == foodMenu.Id);
			    if (menuInDb == null)
				    return BadRequest("null value");
				 
				menuInDb.FoodItems = new List<FoodItem>();

				foreach (var id in foodMenu.FoodItemsId)
			    {
					 menuInDb.FoodItems.Add(_context.FoodItems.SingleOrDefault(f => f.Id == id));
			    }

				menuInDb.ServicePrice = foodMenu.ServicePrice;
				menuInDb.CalFullPrice();
			    menuInDb.Name = foodMenu.Name;
			    menuInDb.FoodItemsId = foodMenu.FoodItemsId; 
			    _context.SaveChanges();
			    return Ok(menuInDb);
		    }

		    if (_context.FoodMenus.Select(f => f.Name).Contains(foodMenu.Name))
		    {
			    return BadRequest("Menu Already Exist");
		    }

		    ValidItem(foodMenu) ; 
			foodMenu.CalFullPrice();

			_context.FoodMenus.Add(foodMenu);
		    _context.SaveChanges();
		    return Created(new Uri(Request.RequestUri+ "/" + foodMenu.Id),foodMenu);
	    }

		private void ValidItem(FoodMenu foodMenu)
		{
			foreach (var i in foodMenu.FoodItemsId)
			{
				foodMenu.FoodItems.Add(_context.FoodItems.SingleOrDefault(f => f.Id == i));
			}
	    }

	    [HttpGet]
	    public ICollection<FoodMenu> GetMenus()
	    {
		    return _context.FoodMenus.Include(f => f.FoodItems).ToList();
	    }

	    [HttpGet]
	    public IHttpActionResult GetMenu(int id)
	    {
		    var menu = _context.FoodMenus.Include(f => f.FoodItems).SingleOrDefault(f => f.Id == id);
		    if (menu == null)
			    return BadRequest("invalid request");

		    return Ok(menu);
	    }

	    [HttpDelete]
	    public IHttpActionResult DeleteMenu(int id)
	    {
		    var menu = _context.FoodMenus.Include(f => f.FoodItems).SingleOrDefault(f => f.Id == id);
		    if (menu == null)
			    return BadRequest("invalid request");

		    _context.FoodMenus.Remove(menu);
		    _context.SaveChanges();
		    return Ok(menu);
	    }

		[HttpPost]
		[Route("api/removeItem/")]
	    public IHttpActionResult RemoveItem(RemoveItem remove)
	    {
		    var menu = _context.FoodMenus.Include(f => f.FoodItems).SingleOrDefault(f => f.Id == remove.MenuId);
		    var item = menu.FoodItems.SingleOrDefault(f => f.Id == remove.ItemId);

			if (menu == null || item == null)
		    {
			    return BadRequest("not valid menuid");
		    }

			menu.FoodItems.Remove(item);

			_context.SaveChanges();

		    return Ok("Deleted");
	    }
    }
}
