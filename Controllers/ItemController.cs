using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcapl1.Models;
using mvcapl1.Models.Data;
using NuGet.Common;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace mvcapl1.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDpContext _db ;
        public ItemController(AppDpContext _db)
        {
            this._db = _db;
        }
       
        public IActionResult Index(int? price)
        {
         
            Console.WriteLine("//////////////////////////////////sssssssssssssss" );
            IEnumerable<Item> itemList = _db.Items.Include(x =>x.category).ToList();
            
            return View(itemList);
        }

        
        //Get
        public IActionResult newItem (int? id)
        {
            createCatList();
            if (id == null) 
            return View();
            else
            {
                var item = _db.Items.Find(id);
                return View(item);  
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult newItem(Item item)
        {
            createCatList();

            if (ModelState.IsValid)
            {

                if (item.Id == 0)
                {
                    _db.Add(item);
                    TempData["sucsess"] = "the item \" " + item.Name + "\" has been adedd sucsessfully ";
                }
                else
                {

                    _db.Update(item);
                    TempData["sucsess"] = "the item \"" + item.Name + "\" has been Edited sucsessfully ";
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
               
            }
        }

        // Get 
        public IActionResult delete(int? id)
        {
            createCatList();
            var item = _db.Items.Find(id);
            return View(item);
        }
        // post
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            
            var item = _db.Items.Find(id);
            _db.Remove(item);
            _db.SaveChanges();
            TempData["sucsess"] = "the item \"" + item.Name + "\" has been Deleted sucsessfully ";
            return RedirectToAction("Index");

        }
      
           
           
        public void createCatList(int selectedId =0 )
        {
            var catlst = _db.Category.ToList();
            ViewBag.catList = new SelectList(catlst, "Id", "Name", selectedId);
        }
    }
}
