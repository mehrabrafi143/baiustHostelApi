using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
	[Authorize]
    public class FoodItemController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public FoodItemController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    public IHttpActionResult Add(FoodItem foodItem)
	    {
		    if (foodItem == null)
			    return BadRequest("Name can't be null");

		    if (foodItem.Id != 0)
		    {
				
			    var item = _context.FoodItems.Include(f => f.FoodMenus).SingleOrDefault(f => f.Id == foodItem.Id);
			    if (item == null)
				    return BadRequest("No item found of given id");

			    var oldPrice = item.PricePerHead;

				item.Name = foodItem.Name;
			    item.PricePerKg = foodItem.PricePerKg;
			    item.PeoplePerKg = foodItem.PeoplePerKg;
			    item.SetPricePerHead();

			    if (item.FoodMenus.Count != 0)
			    {
				    foreach (var foodMenu in item.FoodMenus)
				    {
					    var menu = _context.FoodMenus.SingleOrDefault(f => f.Id == foodMenu.Id);
					    if (menu != null)
					    {
						    menu.FullPrice = menu.FullPrice - oldPrice;
						    menu.FullPrice = menu.FullPrice + item.PricePerHead;
					    }
				    }
			    }

				_context.SaveChanges();
				return Ok(item);
		    }

			if (_context.FoodItems.Any(f => f.Name.ToLower().Contains(foodItem.Name.ToLower())))
			    return BadRequest("Same food can't be added twice!");

			foodItem.SetPricePerHead();
			
		    _context.FoodItems.Add(foodItem);
		    _context.SaveChanges();

		    return Ok(foodItem);
	    }

	    public IHttpActionResult GetItem(int id)
	    {
		    var item = _context.FoodItems.Include(f => f.FoodMenus).SingleOrDefault(f => f.Id == id);
		    if (item == null)
			    return BadRequest("No item found of given id");

		    return Ok(item);
	    }

	    public ICollection<FoodItem> GetItems()
	    {
		    return _context.FoodItems.ToList();
	    }


	    public IHttpActionResult Delete(int id)
	    {
		    var item = _context.FoodItems.SingleOrDefault(f => f.Id == id);
		    if (item == null)
			    return BadRequest("No item found of given id");

		    _context.FoodItems.Remove(item);
		    _context.SaveChanges();
		    return Ok(item);
	    }
    }
}
