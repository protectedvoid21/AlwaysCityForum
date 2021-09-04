using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebForum.Models {
    public class ForumDbContext : DbContext {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options) {}

        public DbSet<ForumUser> ForumUsers { get; set; }

        public DbSet<ForumSection> Sections { get; set; }
        public DbSet<ForumThread> Threads { get; set; }
        public DbSet<ForumPost> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
