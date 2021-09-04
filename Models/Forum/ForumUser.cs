using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class ForumUser {
        public int Id { get; set; }
        public int PostCount { get; set; }
        public List<ForumThread> ForumThreads { get; set; }
    }
}
