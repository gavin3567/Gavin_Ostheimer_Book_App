using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gavin_Ostheimer_Book_App.Models
{
    public class EFSaleRepository : ISaleRepository
    {
        private BookstoreContext context;

        public EFSaleRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Sale> Sales => context.Sales.Include(x => x.Lines).ThenInclude( x => x.Book);

        public void SaveSale(Sale sale)
        {
            context.AttachRange(sale.Lines.Select(x => x.Book));

            if (sale.SaleId == 0)
            {
                context.Sales.Add(sale);
            }

            context.SaveChanges();
        }
    }
}
