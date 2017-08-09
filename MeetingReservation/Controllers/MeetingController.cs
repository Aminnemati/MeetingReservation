using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                meetings = context.Meetings.ToList();
            }
            return View(meetings);
        }
    }
}