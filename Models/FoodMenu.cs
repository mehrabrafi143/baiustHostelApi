using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiustHostel.Models
{
	public class FoodMenu
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public ICollection<FoodItem> FoodItems { get; set; }
		public float FullPrice { get; set; }
		public IList<int> FoodItemsId { get; set; }
		public float ServicePrice { get; set; }
		public FoodMenu()
		{
			FoodItems = new List<FoodItem>();
		}


		public void CalFullPrice()
		{
			var sum = 0.0f;
			foreach (var foodItem in FoodItems)
			{
				sum += foodItem.PricePerHead;
			}

			FullPrice = sum + ServicePrice;
		}
		
	}
}