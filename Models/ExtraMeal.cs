using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiustHostel.Models
{
	public class ExtraMeal
	{
		[Key]
		[Column(Order = 1)]
		public int MealId { get; set; }

		[Key]
		[Column(Order = 2)]
		public int Numbers { get; set; }

		public float TotalAmount { get; set; }

	}
}