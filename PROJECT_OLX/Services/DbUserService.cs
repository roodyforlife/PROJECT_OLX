using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class DbUserService : IDbUserService
    {
        private readonly ApplicationContext _db;
        public DbUserService(ApplicationContext db)
        {
            _db = db;
        }
        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public void Del(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public User Get(string user)
        {
            return _db.Users.FirstOrDefault(x => x.Name == user);
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }
    }
}
