using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Interfaces
{
    public interface IDbApplicationService
    {
        public void Add(Add add);
        public void Del(Add add);
        public List<Add> GetAll();
        public Add Get(int addId);
        public List<Add> GetSome(string userId);
    }
}
