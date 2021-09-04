using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class ForumThread {
        [Key]
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public AppUser Author { get; set; }
        public DateTime PublicationTime { get; set; }
    }
}
