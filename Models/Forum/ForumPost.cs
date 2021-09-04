using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class ForumPost {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AppUser Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
