using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcL.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Роль")]
        public int RoleId { get; set; }
    }
}