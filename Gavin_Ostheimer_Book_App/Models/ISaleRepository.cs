using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gavin_Ostheimer_Book_App.Models
{
    public interface ISaleRepository
    {
        IQueryable<Sale> Sales { get; }

        void SaveSale(Sale sale);
    }
}
