using Demo.Core.Entities;
using System.Collections.Generic;

namespace Demo1.Models
{
    public class NewsViewModel
    {
        public IEnumerable<News> News { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<Ads> Ads { get; set; }
    }
}
