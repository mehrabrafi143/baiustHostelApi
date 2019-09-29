using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiustHostel.Models
{
	public class FoodItem
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		public float PricePerKg { get; set; }

		public float PeoplePerKg { get; set; }

		public float PricePerHead { get; set; }

		public ICollection<FoodMenu> FoodMenus { get; set; }

		public IList<int> FoodMenusId { get; set; }

		public FoodItem()
		{
			FoodMenus = new List<FoodMenu>();
		}

		public void SetPricePerHead()
		{
			if (PeoplePerKg != 0 && PricePerKg != 0)
				PricePerHead = PricePerKg / PeoplePerKg;
		}
	}
}