using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_ASP_MVC_.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Judul")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Isinya")]
        public string Content { get; set; }
        [Required]
        [DisplayName("Tanggal Pembuatan")]
        public DateTime CreateDate { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public User User { get; set; }
    }

    public class BlogDashboard
    {
        public List<Blog> blog { get; set; }
        public List<User> user { get; set; }

        public BlogDashboard()
        {
            blog = new List<Blog>();
            user = new List<User>();
        }
    }

    public class DetailBlog
    {
        public List<Blog> blog { get; set; }

        public DetailBlog()
        {
            blog = new List<Blog>();
        }
    }

}
