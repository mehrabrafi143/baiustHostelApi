using System;

namespace BaiustHostel.Models
{
	public class Notification
	{
		public int Id { get; set; }
		public DateTime? DateTime { get; set; }
		public string OriginalTitle { get; set; }
		public string OriginalDescription { get; set; }
		public NotificationType NotificationType { get; set; }
		public Notice Notice { get; set; }
	}
}