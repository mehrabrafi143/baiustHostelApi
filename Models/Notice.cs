using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiustHostel.Models
{
	public class Notice
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime? CreatedTime { get; set; }
	}
}