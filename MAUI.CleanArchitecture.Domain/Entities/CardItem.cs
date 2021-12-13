using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Domain.Entities
{
    public class CardItem
    {
        public int Quantity { get; set; }

        public StoreItem StoreItem { get; set; } = new StoreItem();

        public decimal CalculatedPrice => StoreItem.Price * Quantity;
    }
}
