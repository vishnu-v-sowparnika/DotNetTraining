using EventManagement.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class Participant
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        [EmailAddress]
        public virtual string Email { get; set; }

        [PhoneNumber]
        public virtual string Phone { get; set; }

        [Display(Name = "Event Title")]
        [ForeignKey("EventModelId")]
        public virtual int? EventModelId { get; set; }

        public virtual EventModel EventModel { get; set; }  

    }
}
