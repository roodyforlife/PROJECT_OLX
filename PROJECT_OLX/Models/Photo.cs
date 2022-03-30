using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Models
{
    public class Photo
    {
        public Photo(byte[] avatar)
        {
            Avatar = avatar;
        }
        public int Id { get; set; }
        public byte[] Avatar { get; set; }
        
    }
}
