using Demo.Core.Entities;
using System.Collections.Generic;

namespace Demo.Core.Contracts
{
    public interface IAdsRepository
    {
        List<Ads> GetAds();
    }
}
