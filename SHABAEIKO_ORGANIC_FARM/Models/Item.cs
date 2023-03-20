using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Models
{
    public class Item
    {
        [Key]
        public int Item_ID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        [DisplayName("Item Image")]
        public string ItImage { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFIle { get; set; }
    }
}
