using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Models
{
    public class AddViewModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int Cost { get; set; }
        public string Desc { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Photo { get; set; }
    }
}
