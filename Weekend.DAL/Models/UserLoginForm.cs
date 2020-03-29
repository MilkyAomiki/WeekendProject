using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weekend.DAL.Models
{
    public partial class UserLoginForm
    {
        [Key]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
