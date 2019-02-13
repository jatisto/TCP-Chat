using System.ComponentModel.DataAnnotations;

namespace TCP_Chat.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name="Логин")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}