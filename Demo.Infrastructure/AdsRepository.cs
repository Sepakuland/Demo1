using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.InfraStructure.EF;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastructure.Data
{
    public class AdsRepository: IAdsRepository
    {
        private readonly DemoContext context;
        public AdsRepository(DemoContext context)
        {
            this.context = context;

        }

        public List<Ads> GetAds()
        {
            return context.Ads.ToList();
        }
    }
}
