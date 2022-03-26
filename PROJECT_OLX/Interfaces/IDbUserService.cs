using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Interfaces
{
    public interface IDbUserService
    {
        public void Add(User user);
        public void Del(User user);
    }
}
