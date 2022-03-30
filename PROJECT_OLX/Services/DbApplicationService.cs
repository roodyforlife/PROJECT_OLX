using Microsoft.EntityFrameworkCore;
using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class DbApplicationService : IDbApplicationService
    {
        private readonly ApplicationContext _db;
        public DbApplicationService(ApplicationContext db)
        {
            _db = db;
        }
        public void Add(Add add)
        {
            _db.Adding.Add(add);
            _db.SaveChanges();
        }
        public void Del(Add add)
        {
            _db.Adding.Remove(add);
            _db.SaveChanges();
        }

        public Add Get(int addId)
        {
            return _db.Adding.Include(x => x.Photos).FirstOrDefault(x => x.Id == addId);
        }

        public List<Add> GetAll()
        {
            return _db.Adding.Include(x => x.Photos).ToList();
        }

        public List<Add> GetSomeBySearch(string search)
        {
            return _db.Adding.Where(x => (x.Title + x.Desc)!.Contains(search)).Include(x => x.Photos).ToList();
        }

        public List<Add> GetSomeByUserName(string userId)
        {
            return _db.Adding.Include(x => x.Photos).ToList().FindAll(x => x.userName == userId);
        }
    }
}
