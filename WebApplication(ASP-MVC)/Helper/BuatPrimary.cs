using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_MVC_.Helper
{
    public class BuatPrimary
    {
        public static string primary()
        {
            Guid buat = Guid.NewGuid();
            return buat.ToString();
        }
    }
}
