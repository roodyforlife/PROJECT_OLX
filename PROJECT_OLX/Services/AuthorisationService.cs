using PROJECT_OLX.Interfaces;
using PROJECT_OLX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PROJECT_OLX.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        public bool IsCorrectPassword(IDbUserService userService, User user)
        {
            var test = userService.Get(user.Name);
            if (user.Password == test.Password)
            {
                return true;
            }
            return false;
        }

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
