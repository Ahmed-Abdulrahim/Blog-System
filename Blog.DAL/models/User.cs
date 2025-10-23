using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required") , MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [DataType(DataType.EmailAddress , ErrorMessage ="Email Is Not Valid") ]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
