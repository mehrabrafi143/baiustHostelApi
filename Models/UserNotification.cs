using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiustHostel.Models
{
	public class UserNotification
	{
		[Key]
		[Column(Order = 1)]
		public int StudentId { get; set; }
		[Key]
		[Column(Order = 2)]
		public int NotificationId { get; set; }
		public bool IsRead { get; set; }
		public Notification Notification { get; set; }
		public Student Student { get; set; }
	}
}