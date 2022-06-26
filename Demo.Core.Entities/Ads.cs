using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Core.Entities
{
    public class Ads
    {
        public int AdsId { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        [Display(Name = "ImagePath")]
        public IFormFile AdsImage { get; set; }
    }
}
