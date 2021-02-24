using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class Organiser
    {
        public virtual int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "First Name ")]
        public virtual string FName { get; set; }
        [Display(Name = "Last Name")]
        public virtual string LName { get; set; }

        [ForeignKey("AddressId")]
        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }

       
    }
}
