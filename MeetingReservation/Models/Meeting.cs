using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingReservation.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Location Location { get; set; }
        public virtual CustomDateTime CustomDateTime { get; set; }
        public virtual ICollection<Attend> Attends { get; set; }
        public virtual Initiator Initiator { get; set; }
    }
}