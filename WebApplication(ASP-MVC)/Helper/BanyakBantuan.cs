using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_MVC_.Helper
{
    public static class BanyakBantuan
    {
        public static int BuatOTP()
        {
            Random r = new();

            return r.Next(1000, 9999);
        }
    }
}
