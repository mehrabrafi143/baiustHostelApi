using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiustHostel.Models
{
	public class UserImage
	{
		public int Id { get; set; }
		public string Path { get; set; }
		public int UserId { get; set; }
	}
}