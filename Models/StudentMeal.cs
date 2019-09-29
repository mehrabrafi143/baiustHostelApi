using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace BaiustHostel.Models
{
	public class StudentMeal
	{
		[Key]
		[Column(Order =  1)]
		public int StudentId { get; set; }

		[Key]
		[Column(Order = 2)]
		public int MealId { get; set; }

		public Student Student { get; set; }

		public Meal Meal { get; set; }

		public string MealToken { get; set; }

		public string RandomString(int size, bool lowerCase)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random();
			char ch;
			for (int i = 0; i < size; i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);
			}
			if (lowerCase)
				return builder.ToString().ToLower();
			return builder.ToString();
		}

		public void AssignToken()
		{
			MealToken = RandomString(8, true);
		}
	}
}