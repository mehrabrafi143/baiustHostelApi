using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiustHostel.Models
{
	public class Sit
	{
		public int Id { get; set; }
		public string Name  { get; set; }
		public IEnumerable<Student> Students { get; set; }
		public Gender Gender { get; set; }
		public int? GenderId { get; set; }
		public int Capacity { get; set; }
		public int OccupiedSit { get; set; }
		public float ElectricityBill { get; set; }
		public float ElectricityBillPerHead { get; set; }
		public Sit()
		{
			Students = new List<Student>();
		}

		public void AssignPerHeadElectricityBill()
		{
			if (OccupiedSit > 0)
			{
				ElectricityBillPerHead = ElectricityBill / OccupiedSit;
			}
			else
			{
				ElectricityBillPerHead = ElectricityBill;
			}

		}
	}
}