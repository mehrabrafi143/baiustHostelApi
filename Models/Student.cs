using System;
using System.Collections.Generic;
using System.Data;

namespace BaiustHostel.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Roll { get; set; }
		public float PaidAmount { get; set; }
		public float DeuAmount { get; set; }
		public string RoomNo { get; set; }
		public string Address { get; set; }
		public DateTime? AddedTime { get; set; }
		public string PhoneNumber { get; set; }
		public string Dept { get; set; }
		public ApplicationUser UserAccount { get; set; }
		public string UserAccountId { get; set; }
	}
}