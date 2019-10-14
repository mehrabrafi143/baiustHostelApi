using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaiustHostel.Dtos;
using BaiustHostel.Models;

namespace BaiustHostel.Controllers
{
    public class SitController : ApiController
    {
	    private readonly ApplicationDbContext _context;

	    public SitController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    public IHttpActionResult Add(Sit sit)
	    {
		    if (sit == null)
			    return BadRequest("null object");

		    if (_context.Sits.Where(s => s.GenderId == sit.GenderId).ToList().Select(s => s.Name).Contains(sit.Name) )
			    return BadRequest("Already exist");

		    if (sit.Id == 0)
		    {
			    _context.Sits.Add(sit);

			}
			else
		    {
			   var  sitInDb = _context.Sits.SingleOrDefault(s => s.Id == sit.Id);
			   if (sitInDb == null)
				   return BadRequest("null object");
			   sitInDb.GenderId = sit.GenderId;
			   sitInDb.Name = sit.Name;
			   sitInDb.Capacity = sit.Capacity;
		    }

			_context.SaveChanges();

		    return Ok(sit);
	    }

		[HttpGet]
		[Route("api/sitname")]
	    public IHttpActionResult GetRoomNameByGender(int id)
	    {
		    return Ok(_context.Sits.Where(s => s.Gender.Id == id).Select(s => s.Name).ToList());
	    }

		[HttpGet]
		[Route("api/sitbygender")]
	    public IHttpActionResult GetByGender(int id)
	    {
		    return Ok(_context.Sits.Include(s => s.Gender).Where(s => s.Gender.Id == id).ToList());
	    }

		[HttpDelete]
		public IHttpActionResult DeletSit(int id)
		{
			var sit = _context.Sits.SingleOrDefault(s => s.Id == id);
			if (sit == null) return BadRequest("not found");

			_context.Sits.Remove(sit);
			_context.SaveChanges();

			return Ok(sit);
		}


		[HttpGet]
		public IHttpActionResult GetSit(int id)
		{
			var sit = _context.Sits.Include(s => s.Gender).SingleOrDefault(s => s.Id == id);
			if (sit == null) return BadRequest("not found");


			return Ok(sit);
		}

		[HttpPost]
		[Route("api/electricBill")]
		public IHttpActionResult AllStudents(ElectricBill electricBill)
		{
			var sit = _context.Sits.SingleOrDefault(s => s.Id == electricBill.RoomId);
			if (sit == null) return BadRequest("no sit in this number");

			sit.ElectricityBill = electricBill.Amount;

			sit.AssignPerHeadElectricityBill();

			var students = _context.Students.Include(s => s.Sit).Where(s => s.Sit.Id == electricBill.RoomId).ToList();
			foreach (var student in students)
			{
				student.DeuAmount += sit.ElectricityBillPerHead;
			}

			_context.SaveChanges();
			return Ok(electricBill);
		}

		[HttpGet]
		[Route("api/availableSits")]
		public IHttpActionResult AvailableSits()
		{
			var arr = new List<int>();
			var mSitCap = _context.Sits.Where(s => s.GenderId == 1).Select(s => s.Capacity).Sum();
			var mSitOc = _context.Sits.Where(s => s.GenderId == 1).Select(s => s.OccupiedSit).Sum();
			arr.Add(mSitCap);
			arr.Add(mSitCap - mSitOc);
			var fSitCap = _context.Sits.Where(s => s.GenderId == 2).Select(s => s.Capacity).Sum();
			var fSitOc = _context.Sits.Where(s => s.GenderId == 2).Select(s => s.OccupiedSit).Sum();
			arr.Add(fSitCap);
			arr.Add(fSitCap - fSitOc);
			return Ok(arr);
		}
		

    }
}
