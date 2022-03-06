using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Models;

namespace WebApplication_ASP_MVC_.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> TampilSemuaData();
        Task<Blog> TampilBLogById(int id);
        Task<bool> BuatBlog(Blog datanya, string username);
        Task<bool> HapusBlog(int id);
        Task<bool> UpdateBlogAsync(Blog data);
    }
}
