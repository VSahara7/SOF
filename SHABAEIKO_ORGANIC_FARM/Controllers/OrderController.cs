using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SHABAEIKO_ORGANIC_FARM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbcontext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OrderController(ApplicationDbcontext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
