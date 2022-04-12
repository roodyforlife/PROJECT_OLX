using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Models
{
    public class SearchViewModel
    {
        public CategoryViewModel Category { get; set; }
        public string Input { get; set; }
        public string Sort { get; set; }
    }
}
