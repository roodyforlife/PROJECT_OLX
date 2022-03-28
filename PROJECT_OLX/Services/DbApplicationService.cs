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
        private readonly ApplicationContext db;
        public DbApplicationService(ApplicationContext db)
        {
            this.db = db;
        }
        public void Add(Add add)
        {
            db.Adding.Add(add);
            db.SaveChanges();
        }
        public void Del(Add add)
        {
            db.Adding.Remove(add);
            db.SaveChanges();
        }

        public Add Get(int addId)
        {
            return db.Adding.FirstOrDefault(x => x.Id == addId);
        }

        public List<Add> GetAll()
        {
            return db.Adding.ToList();
        }

        public List<Add> GetSomeByUserName(string userId)
        {
            return db.Adding.ToList().FindAll(x => x.userName == userId);
        }
    }
}
