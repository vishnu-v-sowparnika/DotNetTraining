using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class Address
    {
        public virtual int Id { get; set; }

        [Display(Name = "Address 1")]
        public virtual string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public virtual string Address2 { get; set; }

        [Display(Name = "ZIP Code/PO box")]
        public virtual string POBOX { get; set; }

       
        public virtual string State { get; set; }

        public virtual string City { get; set; }


        public virtual Organiser AssociatedOrganiser { get; set; }

    }
}
