using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class ChangeEmailViewModel {
        [Required]
        [Display(Name = "New email")]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }
        [Required]
        [Compare("NewEmail")]
        [Display(Name = "New email confirmation")]
        [DataType(DataType.EmailAddress)]
        public string NewEmailConfirmation { get; set; }
        [Required]
        [Display(Name = "Current password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
