using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SHABAEIKO_ORGANIC_FARM.Data;
using SHABAEIKO_ORGANIC_FARM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbcontext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ItemController(ApplicationDbcontext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item obj)
        {
            string wwwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(obj.ImageFIle.FileName);
            string extension = Path.GetExtension(obj.ImageFIle.FileName);
            obj.ItImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await obj.ImageFIle.CopyToAsync(fileStream);
            }

            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
/*        public IActionResult Update()
        {
            return View();
        }*/
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Update(Item obj)
        {
           
            if (ModelState.IsValid)
            {
                string wwwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(obj.ImageFIle.FileName);
                string extension = Path.GetExtension(obj.ImageFIle.FileName);
                obj.ItImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await obj.ImageFIle.CopyToAsync(fileStream);
                }
                _db.Items.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
   /*     public IActionResult Delete()
        {
            return View();
        }*/
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Item obj)
        {
           
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            /* var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", obj.ItImage);
             if (System.IO.File.Exists(imagePath))
                 System.IO.File.Delete(imagePath);
 */
           
        }
      
        public IActionResult Details()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
      

        public IActionResult Cart(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int? id)
        {
            var obj = _db.Items.Find(id);


            if (obj == null)
            {
                return NotFound();
            }
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        



    }
    }

