using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebForum.Models {
    public class ArticleNewsViewModel {
        public int Id { get; set; }
        public DateTime PublicationDate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ContentText { get; set; }
        public string Author { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
