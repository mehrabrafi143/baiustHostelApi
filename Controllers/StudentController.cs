using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BaiustHostel.Dtos;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class StudentController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public StudentController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    public IHttpActionResult AddStudent(Student student)
	    {
		    if (!ModelState.IsValid)
			    return BadRequest("bad request");

		    if (student.Id == 0)
		    {
			    var userAccount = _context.Users.Find(student.UserAccountId);
			    userAccount.Student = student;
			    student.AddedTime = DateTime.Now;

			    var rooList = _context.Students.Select(s => s.Roll).ToList();

			    if (rooList.Contains(student.Roll))
				    return BadRequest("Same Roll can't be added twice");

			    _context.Students.Add(student);
			}
		    else
		    {
			    var studentInDb = _context.Students.SingleOrDefault(s => s.Id == student.Id);

			    if (studentInDb == null)
				    return BadRequest("no student found");

			    studentInDb.Name = student.Name;
			    studentInDb.Address = student.Address;
			    studentInDb.PhoneNumber = student.PhoneNumber;
			    studentInDb.Roll = student.Roll;
			    studentInDb.RoomNo = student.RoomNo;
			    studentInDb.Dept = student.Dept;
		    }



		    _context.SaveChanges();
		    return Ok(student);
	    }

	    public IEnumerable<Student> GetStudents()
	    {
		    return _context.Students.ToList();
	    }

		[HttpGet]
		public IHttpActionResult GetStudentById(int id)
		{
			var student = _context.Students.SingleOrDefault(s => s.Id == id);
			if (student == null)
				return BadRequest("Not a valid id");
			return Ok(student);
		}

		[HttpDelete]
		public IHttpActionResult DeleteStudent(int id)
		{
			var student = _context.Students.Include(s => s.UserAccount).SingleOrDefault(s => s.Id == id);
			if (student == null) return BadRequest("null id");
			if (student.UserAccount == null)
				return BadRequest("no user found");

			_context.Users.Remove(student.UserAccount);
			_context.Students.Remove(student);
			_context.SaveChanges();

			return Ok(student);

		}
		
		[HttpGet]
		[Route("api/get/")]
	    public Student GetStudent(string username)
	    {
		    var user = _context.Students.Single(s => s.UserAccount.UserName == username);
		    
		    return user;
	    }
		[Route("api/ImageUpload")]
		[HttpPost]
	    public HttpResponseMessage ImageUpload()
	    {
			string imageName = null;
			var httpRequest = HttpContext.Current.Request;
			//Upload Image
			var postedFile = httpRequest.Files["image"];
			var userId = Convert.ToInt32(httpRequest["userId"]);
			
			//Create custom filename
			imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
			imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
			var filePath = HttpContext.Current.Server.MapPath("~/Userimage/" + imageName);
			postedFile.SaveAs(filePath);

			//Save to DB

			var userImage = new UserImage
			{
				UserId = userId,
				Path = filePath
			};

			_context.UserImage.Add(userImage);
			_context.SaveChanges();

			return Request.CreateResponse(HttpStatusCode.Created);

		}

	    [Route("api/ImageUpload")]
	    [HttpGet]
		public UserImage GetImages(int id)
		{
			return _context.UserImage.SingleOrDefault(f => f.UserId == id);
		}

		[Route("api/studentsPay")]
	    [HttpPost]
		public IHttpActionResult StudentPay(StudentsPay studentsPay)
		{
			var studentInDb = _context.Students.SingleOrDefault(s => s.Id == studentsPay.StudentId);

			if (studentInDb == null)
				return BadRequest("not found");

			studentInDb.DeuAmount -= studentsPay.Amount;
			studentInDb.PaidAmount += studentsPay.Amount;

			_context.StudentsPays.Add(studentsPay);
			_context.SaveChanges();
			return Ok(studentsPay);
		}

		

	}
}
