using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class EditUserViewModel {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public class RoleListViewModel {
            public string Id { get; set; }
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }

        public List<RoleListViewModel> RoleList { get; set; }
    }
}
