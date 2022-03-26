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
        public DbApplicationService(ApplicationContext _db)
        {
            db = _db;
        }
        public void Add(Add add)
        {
            db.Adding.Add(add);
            db.SaveChanges();
        }
    }
}
