using PROJECT_OLX.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Models
{
    public class LoginUser
    {
        [RegularExpression(@"[A-Za-z0-9_]+", ErrorMessage = "У імені може бути лише латинські літери та знак '_'")]
        [IsSpace(ErrorMessage = "Логін не повиннен містити пробілів")]
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Довжина логіну має бути від 3 до 15 символів")]
        public string Login { get; set; }
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "У паролі може бути лише латинські літери")]
        [IsSpace(ErrorMessage = "Пароль не повиннен містити пробілів")]
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Довжина пароля має бути від 6 до 20 символів")]
        public string Password { get; set; }
    }
}
