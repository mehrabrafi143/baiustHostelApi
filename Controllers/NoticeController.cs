using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class NoticeController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public NoticeController()
	    {
		    _context = new ApplicationDbContext();
	    }

		[HttpPost]
	    public IHttpActionResult AddNotice(Notice notice)
	    {
		    if (notice.Title == null || notice.Description == null)
			    return BadRequest("both field should be filled");


		    if (notice.Id != 0)
		    {
			    var noticeInDb = _context.Notics.SingleOrDefault(n => n.Id == notice.Id);
			    if (noticeInDb != null)
			    {
				    var updateNotification = new Notification
				    {
					    DateTime = DateTime.Now,
					    OriginalDescription = noticeInDb.Description,
						OriginalTitle = noticeInDb.Title,
						Notice = notice,
						NotificationType = NotificationType.Updated
				    };

				    var studentsList = _context.Students.ToList();

				    foreach (var student in studentsList)
				    {
					    var userNotification = new UserNotification
					    {
						    Student = student,
						    Notification = updateNotification
					    };
					    _context.UserNotifications.Add(userNotification);
				    }


					noticeInDb.Description = notice.Description;
				    noticeInDb.Title = notice.Title;
				    _context.SaveChanges();
				    return Ok(noticeInDb);
			    }

			    return BadRequest("no notice found of given id");

		    }

		    notice.CreatedTime = DateTime.Now;

			var notification = new Notification
			{
				DateTime = DateTime.Now,
				Notice = notice,
				NotificationType = NotificationType.Created
			};

			var students = _context.Students.ToList();

			foreach (var student in students)
			{
				var userNotification = new UserNotification
				{
					Student = student,
					Notification = notification
				};
				_context.UserNotifications.Add(userNotification);
			}
			
		    _context.Notics.Add(notice);
		    _context.SaveChanges();

		    return Ok(notice);
	    }

		[HttpDelete]
	    public IHttpActionResult DeleteNotice(int id)
	    {
		    var noticeInDb = _context.Notics.SingleOrDefault(n => n.Id == id);

		    if (noticeInDb != null)
		    {
			    _context.Notics.Remove(noticeInDb);
			    _context.SaveChanges();
			    return Ok(noticeInDb);
		    }

		    return BadRequest("no notice found of given id");
		}

		[HttpGet]
		public IEnumerable<Notice> GetNotices()
		{
			return _context.Notics.ToList();
		}

		[HttpGet]
		public IHttpActionResult GetNotice(int id)
		{
			var noticeInDb = _context.Notics.SingleOrDefault(n => n.Id == id);

			if (noticeInDb != null)
			{
				return Ok(noticeInDb);
			}

			return BadRequest("no notice found of given id");
		}
    }
}
