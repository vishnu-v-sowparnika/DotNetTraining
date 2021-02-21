using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class EventModel
    {
        public virtual int Id { get; set; } 

        public virtual string Description { get; set; }

        [Display(Name = "Event Date")]
        public virtual DateTime Eventdate { get; set; }

        public virtual string Venue { get; set; }

        [Display(Name = "Registration Start")]
        public virtual DateTime Reg_start_date { get; set; }

        [Display(Name = "Registration Ends")]
        public virtual DateTime Reg_end_date { get; set; }

        [Display(Name = "Organiser")]
        [ForeignKey("organiserId")]
        public virtual int? organiserId { get; set; }
        public virtual Organiser organiser { get; set; }

        public virtual ICollection<Participant> participants { get; set; }
    }
}
