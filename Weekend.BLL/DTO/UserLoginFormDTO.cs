using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weekend.BLL.DTO
{
    public class UserLoginFormDTO
    {

        [Key]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
