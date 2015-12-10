using System.Collections.Generic;
using Company.Types;

namespace Company.Interfaces
{
    public interface ISalesEmployee
    {
        List<Sale> Sales { get; set; }
        void AddSale(Sale sale);
    }
}