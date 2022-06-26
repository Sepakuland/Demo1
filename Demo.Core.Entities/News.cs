using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Core.Entities
{
    public class News
    {
        public News()
        {
            PubDate = DateTime.Now;
        }
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Summery { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }

        public DateTime PubDate { get; set; }
        [NotMapped]
        [Display(Name = "ImagePath")]
        public IFormFile Images { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
