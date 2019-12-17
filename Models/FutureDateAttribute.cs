using System;
using System.ComponentModel.DataAnnotations;

namespace CBelt.Models
{
    internal class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime)value > DateTime.Now;
        }
    }
}