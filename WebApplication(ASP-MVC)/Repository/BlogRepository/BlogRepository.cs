using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Models;

namespace WebApplication_ASP_MVC_.Repository.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _blogDB;
        public BlogRepository(AppDbContext b)
        {
            _blogDB = b;
        }
        public async Task<List<Blog>> TampilkanSemuaBlogAsync()
        {
            var data = await _blogDB.Tb_Blog.ToListAsync();
            return data;
        }
        public async Task<Blog> TampilBlogByIdAsync(int id)
        {
            return await _blogDB.Tb_Blog.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> BuatBlogAsync(Blog datanya)
        {
            _blogDB.Tb_Blog.Add(datanya);
            await _blogDB.SaveChangesAsync();
            
            return true;
        }
        public async Task<User> CariUserByUsernameAsync(string username)
        {
            return await _blogDB.Tb_User.FirstOrDefaultAsync(x => x.Username == username);
        }
        public async Task<bool> HapusBlogAsync(Blog datanya)
        {
            _blogDB.Tb_Blog.Remove(datanya);
            await _blogDB.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateBlogAsync(Blog datanya)
        {
            _blogDB.Tb_Blog.Update(datanya);
            await _blogDB.SaveChangesAsync();

            return true;
        }

        

        
    }
}
