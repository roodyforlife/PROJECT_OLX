using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_OLX.Models
{
    public class Add
    {
        [Key]
        public int Id { get; set; }
        public string userName { get; set; }
        //public User User { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Ціна має складатися тільки з цифр")]
        public int Cost { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [StringLength(450, MinimumLength = 10, ErrorMessage = "Довжина опису має бути від 10 до 450 символів")]
        public string Desc { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Довжина назви має бути від 5 до 100 символів")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [EmailAddress(ErrorMessage = "Некоректна email-адреса")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Це обов'язкове поле")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Номер телефону має бути у цифровому форматі")]
        public string Phone { get; set; }
        //VVVVVV   Загрузка фото    VVVVVVVV
        //public string Path { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

    }
}
