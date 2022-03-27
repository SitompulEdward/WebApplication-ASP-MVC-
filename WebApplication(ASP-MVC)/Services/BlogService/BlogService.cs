using Microsoft.AspNetCore.Http;
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
        private readonly FileService _file;

        public BlogService(IBlogRepository r, FileService f)
        {
            _blogRepo = r;
            _file = f;
        }

        public async Task<bool> BuatBlog(Blog datanya, string username, IFormFile foto)
        {
            //datanya.Id = BuatPrimary.primary();
            var cariUser = await _blogRepo.CariUserByUsernameAsync(username);
            datanya.User = cariUser;

            datanya.Image = await _file.SimpanFile(foto);

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
