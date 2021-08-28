using System.ComponentModel.DataAnnotations;

namespace WebForum.Models {
    public class EditPasswordViewModel {
        [Required, Display(Name = "Current password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required, Display(Name = "New password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, Display(Name = "New password confirmation")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string NewPasswordConfirmation { get; set; }
    }
}