using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class Organiser
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        [ForeignKey("AddressId")]
        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
