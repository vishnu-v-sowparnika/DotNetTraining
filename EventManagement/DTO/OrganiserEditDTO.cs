using EventManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.DTO
{
    public class OrganiserEditDTO
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual string FName { get; set; }
        public virtual string LName { get; set; }

        public virtual string Address1 { get; set; }

        public virtual string Address2 { get; set; }

        public virtual string POBOX { get; set; }

        public virtual string State { get; set; }

        public virtual string City { get; set; }

        public Address GetAddress()
        {
            return new Address()
            {
                Address1 = this.Address1,
                Address2 = this.Address2,
                City = this.City,
                State=this.State,
                POBOX=this.POBOX
            };
        }

        public Organiser GetOrganiser()
        {
            return new Organiser()
            {
                Email=this.Email,
                Password=this.Password,
                Id=this.Id,
                FName=this.FName,
                LName=this.LName
            };
        }
    }
}
