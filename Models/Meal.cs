using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiustHostel.Models
{
	public class Meal
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public FoodMenu FoodMenu { get; set; }

		public float FullPrice { get; set; }
	}
}