using System.ComponentModel.DataAnnotations;

namespace WebForum.Models {
    public class RoleViewModel {
        [Required]
        public string Name { get; set; }
    }
}