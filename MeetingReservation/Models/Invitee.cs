using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingReservation.Models
{
    public class Invitee : User
    {
        public virtual ICollection<Attend> Attends { get; set; }
    }
}