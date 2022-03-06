using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Models;

namespace WebApplication_ASP_MVC_.Repository.BlogRepository
{
    public interface IBlogRepository
    {
        Task<bool> BuatBlogAsync(Blog datanya);
        Task<List<Blog>> TampilkanSemuaBlogAsync();
        Task<Blog> TampilBlogByIdAsync(int id);
        Task<bool> UpdateBlogAsync(Blog datanya);
        Task<bool> HapusBlogAsync(Blog datanya);
        Task<User> CariUserByUsernameAsync(string username);

    }
}
