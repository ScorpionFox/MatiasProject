using System.ComponentModel.DataAnnotations;

namespace MatiasProject.Models.DTO
{
    public class ChangePasswordModel
    {

        [Required]
        public string? CurrentPassword { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum 6 znaków, musi zawierać 1 cyfre, 1 dużą litere, 1 małą litere, 1 znak specjalny")]
        public string? NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string? PasswordConfirm { get; set; }    
    }
}
