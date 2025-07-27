using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestCoreApp.Data;
using TestCoreApp.Models;

namespace TestCoreApp.Controllers
{
    public class ItemsController : Controller //Page of the items 
    {
        private readonly AppDbContext _db;
        public ItemsController(AppDbContext db) //retrive data from server to program we Created a constructor and passed parameters AppDbContext db
        {
            _db = db;

        }

        public IActionResult Index() // This is a method when user click it will start function and execute  
        {
            IEnumerable<Item> itemsList = _db.Items.ToList(); // list for me all data in SQL and store them in itemsList
            return View(itemsList); //we will return the list if all data to views/Items/Index.cshtml frontend

        }
        //Get
        public IActionResult New()
        {
            CreateSelectList();
            return View();
        }
        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (int.TryParse(item.Name, out int number))
            {
                if (number >= -10000 && number <= 10000) // define your range here
                {
                    ModelState.AddModelError("Name", "Name cannot be a number only.");
                }
            }

            /*  if (item.Name == "100")
              {
                  ModelState.AddModelError("Name", "Name cant equal 100");
              } */
            if (ModelState.IsValid)
            {


                _db.Items.Add(item); //This will add items from the frontend to the data (_db)
                _db.SaveChanges(); //Will add new row + add data
                TempData["successData"] = "Item has been added successfully"; //Temprorary data will be shown to the user 
                return RedirectToAction("Index"); //it will load the list again to see what did u add 

            }
            else
            {
                return View(item);
            }
        }
        public void CreateSelectList(int SelectId = 1)
        {
            /* List<Category> categories = new List<Category>
             {
                 new Category() { Id = 0, Name = "Electric Machine" },
                 new Category() { Id = 1, Name = "Computer" },
                 new Category() { Id = 2, Name = "Mobile" },
                 new Category() { Id = 3, Name = "Non of the above" }
             }; */
            List<Category> categories = _db.Categories.ToList(); //will give the categories from the database
            SelectList listItems = new SelectList(categories,"Id","Name", SelectId);
            ViewBag.CategoryList = listItems;
        }

        //Get
        public IActionResult Edit(int? Id) //Used for insuring Id is avaliable for editing
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            //  var item = _db.Items.FirstOrDefault(x => x.Id == Id);
            var item = _db.Items.Find(Id); //if not found will return null
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategortId);
            return View(item);
        }
        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (int.TryParse(item.Name, out int number))
            {
                if (number >= -10000 && number <= 10000) // define your range here
                {
                    ModelState.AddModelError("Name", "Name cannot be a number only.");
                }
            }

            /*  if (item.Name == "100")
              {
                  ModelState.AddModelError("Name", "Name cant equal 100");
              } */
            if (ModelState.IsValid)
            {


                _db.Items.Update(item); //This will add items from the frontend to the data (_db)
                _db.SaveChanges(); //Will add new row + add data
                TempData["successData"] = "Item has been updated successfully";
                return RedirectToAction("Index"); //it will load the list again to see what did u add 
            }
            else
            {
                return View(item);
            }


        }
        //Get
        public IActionResult Delete(int? Id) //Used for insuring Id is avaliable for editing
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            //  var item = _db.Items.FirstOrDefault(x => x.Id == Id);
            var item = _db.Items.Find(Id); //if not found will return null
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategortId);
            return View(item);
        }
        //Post 
        [HttpPost, ActionName("Delete")] //Action name used to delete by the name 
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? Id)
        {
            var item = _db.Items.Find(Id);
            if (item == null) { 
                return NotFound();
            }
            _db.Remove(item);
            _db.SaveChanges();
            TempData["successData"] = "Item has been deleted successfully";
            return RedirectToAction("Index");
       

        }
    }
}
