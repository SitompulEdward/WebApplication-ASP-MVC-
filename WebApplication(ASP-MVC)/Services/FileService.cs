using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_MVC_.Services
{
    public class FileService
    {
        IWebHostEnvironment _file;
        public FileService(IWebHostEnvironment e)
        {
            _file = e;
        }

        public async Task<string> SimpanFile(IFormFile filenya)
        {
            string namaFolder = "Foto";

            //cek filenya
            if(filenya == null)
            {
                return string.Empty;
            }

            // set di wwwroot/namaFolder
            var savepath = Path.Combine(_file.WebRootPath, namaFolder);

            // cek foldernya ada atau tidak
            if (!Directory.Exists(savepath))
            {
                //jika tidak ada maka di buat folder baru nya
                Directory.CreateDirectory(savepath);
            }

            // set nama file
            var namaFile = filenya.FileName;

            // set alamat file
            var alamatFile = Path.Combine(savepath, namaFile);

            // proses copy file ke folder
            using(var fotonya = new FileStream(alamatFile, FileMode.Create))
            {
                await filenya.CopyToAsync(fotonya);
            }

            //return alamat file
            return Path.Combine("/" + namaFolder + "/" + namaFile);

        }
    }
}
