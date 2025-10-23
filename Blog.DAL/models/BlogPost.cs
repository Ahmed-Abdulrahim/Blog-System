using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required"), MaxLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is Required")]
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }
        public User Users { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
