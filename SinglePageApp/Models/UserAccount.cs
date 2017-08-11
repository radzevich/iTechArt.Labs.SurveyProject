using System.ComponentModel.DataAnnotations;

namespace SinglePageApp.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Неверный e-mail")]
        [Required(ErrorMessage = "Введите логин (e-mail)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
    }
}