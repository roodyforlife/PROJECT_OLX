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
        public void MakeAdmin(string userId);
        public void Del(User user);
        public User Get(string user);
        public List<User> GetAll();
        public void BlockOrUnblock(User user);
    }
}
