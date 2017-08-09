using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingReservation.Models
{
    public class Attend
    {
        public int Id { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual Invitee Invitee { get; set; }
    }
}