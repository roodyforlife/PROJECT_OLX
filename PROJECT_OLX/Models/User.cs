using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJECT_OLX.Models;
using System.ComponentModel.DataAnnotations;
using PROJECT_OLX.Annotations;

namespace PROJECT_OLX.Models
{
    public class User
    {
        [Key]
        [RegularExpression(@"[A-Za-z0-9_]+", ErrorMessage = "У імені може бути лише латинські літери та знак '_'")]
        [IsSpace(ErrorMessage = "Логін не повиннен містити пробілів")]
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Довжина логіну має бути від 3 до 15 символів")]
        public string Login { get; set; }
        [IsSpace(ErrorMessage = "Ім'я не повинно містити пробілів")]
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Довжина імені має бути від 3 до 12 символів")]
        public string Name { get; set; }
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "У паролі може бути лише латинські літери")]
        [IsSpace(ErrorMessage = "Пароль не повиннен містити пробілів")]
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Довжина пароля має бути від 6 до 20 символів")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [EmailAddress(ErrorMessage = "Некоректна email-адреса")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Номер телефону має бути у цифровому форматі")]
        public string Phone { get; set; }
        public bool IsBanned { get; set; }
        public bool IsAdmin { get; set; }
        public byte[] Avatar { get; set; }
        public List<Add> Adds = new();
    }
}
