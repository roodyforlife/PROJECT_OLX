using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Annotations
{
    public class IsSpace : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value != null)
            {
                return !value.ToString().Contains(" ");
            }
            return true;
        }
    }
}
