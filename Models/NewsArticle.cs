using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class NewsArticle {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ContentText { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
