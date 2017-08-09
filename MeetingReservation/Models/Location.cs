using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingReservation.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Facilities { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}