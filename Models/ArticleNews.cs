using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Models {
    public class ArticleNews {
        public int Id { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string Author { get; set; }
        public string ImagePath { get; set; }
    }
}
