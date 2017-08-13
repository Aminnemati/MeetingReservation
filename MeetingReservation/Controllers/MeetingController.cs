using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MeetingReservation.DAL;
using MeetingReservation.Models;

namespace MeetingReservation.Controllers
{
    public class MeetingController : Controller
    {
        // GET: Meeting
        public ActionResult Index()
        {
            List<Meeting> meetings;
            using (var context=new MeetingContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                meetings = context.Meetings.ToList();

            }
            return View(meetings);
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var context=new MeetingContext())
            {
                ViewBag.locations = context.Locations.ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            using (var contex = new MeetingContext())
            {
                using (var db = contex.Database.BeginTransaction())
                {
                    try
                    {
                        meeting.Location = contex.Locations.Find(meeting.Location.Id);
                        contex.Meetings.Add(meeting);
                        contex.SaveChanges();
                        db.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        db.Rollback();
                        throw;
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}