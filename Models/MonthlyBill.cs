using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiustHostel.Models
{
	public class MonthlyBill
	{
		public int Id { get; set; }
		public float RoomBill { get; set; }
		public float ServicePrice { get; set; }
	}
}