using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCYaJia.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("帳號")]
        public string Username { get; set; }
        [Required]
        [DisplayName("密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}