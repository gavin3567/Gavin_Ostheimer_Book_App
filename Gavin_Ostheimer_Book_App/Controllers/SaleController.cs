using Gavin_Ostheimer_Book_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gavin_Ostheimer_Book_App.Controllers
{
    public class SaleController : Controller
    {
        private ISaleRepository repo { get; set; }
        private Basket basket { get; set; }

        public SaleController(ISaleRepository temp, Basket ba)
        {
            repo = temp;
            basket = ba;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Sale());
        }

        [HttpPost]
        public IActionResult Checkout(Sale sale)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                sale.Lines = basket.Items.ToArray();
                repo.SaveSale(sale);
                basket.ClearBasket();

                return RedirectToPage("/SaleCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
