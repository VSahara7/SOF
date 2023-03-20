using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Models
{
    public class OrderItem
    {
        [Key]
        public int O_Id { get; set; }
        public int O_qty { get; set; }
        public double o_Price { get; set; }

        public int Item_Id { get; set; }

    }
}
