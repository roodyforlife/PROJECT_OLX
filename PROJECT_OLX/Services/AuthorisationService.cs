using PROJECT_OLX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        public bool IsRegistered(IDbUserService userService, string user)
        {
            if(userService.Get(user) is null)
            {
                return false;
            }
            return true;
        }
    }
}
