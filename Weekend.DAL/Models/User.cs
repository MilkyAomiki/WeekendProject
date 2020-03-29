using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weekend.DAL.Models
{
    public partial class User
    {
        [Key]
        [EmailAddress]
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
        public byte[] Avatar { get; set; }
    }
}
