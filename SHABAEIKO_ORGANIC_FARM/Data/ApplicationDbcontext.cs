using Microsoft.EntityFrameworkCore;
using SHABAEIKO_ORGANIC_FARM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Data
{
    public class ApplicationDbcontext: DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users{ get; set; }

       
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> shoppingCartItems { get; set; }
    }

}

