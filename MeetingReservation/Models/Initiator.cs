using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingReservation.Models
{
    public class Initiator : User
    {
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}