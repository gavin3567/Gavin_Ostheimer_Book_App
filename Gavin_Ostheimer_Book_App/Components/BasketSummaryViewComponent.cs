using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gavin_Ostheimer_Book_App.Models; // Replace this with the appropriate namespace that contains your "Basket" model

namespace Gavin_Ostheimer_Book_App.Components
{
    public class BasketSummaryViewComponent : ViewComponent
    {
        private Basket basket;

        public BasketSummaryViewComponent(Basket basketService)
        {
            basket = basketService;
        }

        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
