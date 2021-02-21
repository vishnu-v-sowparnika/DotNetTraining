using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.CustomValidators
{
    public class PhoneNumberAttribute :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string number = value as string;
            if (number.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
