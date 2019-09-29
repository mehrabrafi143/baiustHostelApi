using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class NotificationController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public NotificationController()
	    {
		    _context = new ApplicationDbContext();
	    }

		[HttpGet]
	    public IHttpActionResult StudentsNotification(int id)
	    {
		    var notifications =  _context.UserNotifications
			    .Include(un => un.Notification)
			    .Where(un => un.StudentId == id && !un.IsRead)
			    .Select(un => un.Notification).Include(n => n.Notice).ToList();
		    return Ok(notifications);
	    }


	    [HttpPost]
	    public IHttpActionResult ReadNotification(int id)
	    {
		    var notifications =  _context.UserNotifications
			    .Where(un => un.StudentId == id && !un.IsRead).ToList();

		    foreach (var userNotification in notifications)
		    {
			    userNotification.IsRead = true;
		    }

		    _context.SaveChanges();
		    return Ok(notifications);
	    }

		[HttpGet]
		[Route("api/recentNotifications")]
		public IHttpActionResult GetRecent(int id)
		{
			var notifications = _context.UserNotifications
				.Include(un => un.Notification)
				.Where(un => un.StudentId == id)
				.Select(un => un.Notification).Include(n => n.Notice).OrderByDescending(f => f.DateTime).Take(3).ToList();
			return Ok(notifications);
		}
    }
}
