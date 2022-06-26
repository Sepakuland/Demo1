using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.InfraStructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.ViewComponents
{
    public class AdsViewComponent: ViewComponent
    {
        IAdsRepository adsRepository;
        public AdsViewComponent(IAdsRepository adsRepository)
        {
            this.adsRepository = adsRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Ads> model = adsRepository.GetAds();
            return View(model);
        }
    }
}
