using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_MVC_.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Blog> Tb_Blog { get; set; }
        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }

    }
}
