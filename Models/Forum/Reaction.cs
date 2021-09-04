using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class Reaction {
        public int Id { get; set; }
        public enum LikeType { UpVote, DownVote }
        public AppUser User { get; set; }
        public LikeType ReactionType { get; set; }
    }
}
