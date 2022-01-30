using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication_ASP_MVC_.Helper
{
    public static class DapatkanIdentitas
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(x => x.Type == "Username")?
                                                    .Value ?? string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
