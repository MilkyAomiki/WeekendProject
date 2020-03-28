using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weekend.BLL.DTO
{
    public class UserDTO
    {

        [Key]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        [StringLength(50)]
        public string Sex { get; set; }
        [StringLength(50)]
        public string Language { get; set; }
        [StringLength(50)]
        public string Relationship { get; set; }
        [Column(TypeName = "image")]
        public byte[] Avatar { get; set; }
    }
}
