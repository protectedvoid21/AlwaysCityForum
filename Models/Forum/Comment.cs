using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class Comment {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public AppUser Author { get; set; }
        public string Content { get; set; }
        public List<Reaction> ReactionList { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
