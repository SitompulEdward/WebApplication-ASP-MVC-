using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_MVC_.Helper
{
    public static class ResponApi
    {
        public static object Respon(string stat, int code, string pesan, object datanya)
        {
            return new
            {
                status = stat,
                respon_code = code,
                message = pesan,
                data = datanya
            };
        }
    }
}
