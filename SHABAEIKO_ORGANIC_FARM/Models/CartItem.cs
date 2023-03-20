using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Models
{
    public class CartItem
    {
        [Key]
        public int Cart_ID { get; set; }
        public int Item_ID { get; set; }

        public string ItemName { get; set; }

        public int Price { get; set; }

        public Nullable<int> O_qty { get; set; }

        public Nullable<double> o_Price { get; set; }
    }
}
