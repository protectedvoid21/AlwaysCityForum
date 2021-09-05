using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class ForumPost {
        [Key]
        public int Id { get; set; }
        public int ThreadId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
