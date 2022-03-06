using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_ASP_MVC_.Helper;
using WebApplication_ASP_MVC_.Models;
using WebApplication_ASP_MVC_.Repository.BlogRepository;

namespace WebApplication_ASP_MVC_.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepo;

        public BlogService(IBlogRepository r)
        {
            _blogRepo = r;
        }

        public async Task<bool> BuatBlog(Blog datanya, string username)
        {
            //datanya.Id = BuatPrimary.primary();
            var cariUser = await _blogRepo.CariUserByUsernameAsync(username);
            datanya.User = cariUser;

            return await _blogRepo.BuatBlogAsync(datanya);
        }

        public async Task<bool> HapusBlog(int id)
        {
            var cari = await _blogRepo.TampilBlogByIdAsync(id);
            await _blogRepo.HapusBlogAsync(cari);

            return true;
        }

        public async Task<Blog> TampilBLogById(int id)
        {
            return await _blogRepo.TampilBlogByIdAsync(id);
        }

        public async Task<List<Blog>> TampilSemuaData()
        {
            return await _blogRepo.TampilkanSemuaBlogAsync();
        }

        public async Task<bool> UpdateBlogAsync(Blog data)
        {
            await _blogRepo.UpdateBlogAsync(data);

            return true;
        }
    }
}
