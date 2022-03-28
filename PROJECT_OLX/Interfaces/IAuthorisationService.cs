using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Interfaces
{
    public interface IAuthorisationService
    {
        public bool IsRegistered(IDbUserService userService, string user);
    }
}
