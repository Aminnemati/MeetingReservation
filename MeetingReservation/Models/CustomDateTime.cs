using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingReservation.Models
{
    public class CustomDateTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public virtual Meeting Meeting { get; set; }
    }
}