using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ToDoListContext _db;

        // In the constructor, we set the value of our new _db property to our ToDoListContext db. The ToDoListContext db parameter is passed an argument through dependency injection when our web application host is built. The argument that gets passed into the ItemsController constructor is the exact ToDoListContext that we set up as a service in Program.cs
        public ItemsController(ToDoListContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            // ToList is a Linq method, new way to GetAll()
            // db is an instance of our ToDoListContext class. It's holding a reference to our database.
            // Once there, it looks for an object named Items. This is the DbSet we declared in ToDoListContext.cs
            //             LINQ turns this DbSet into a list using the ToList() method, which comes from the System.Linq namespace.
            // The whole expression _db.Items.ToList() is what creates the model we'll use for the Index view.
            List<Item> model = _db.Items.ToList();
            return View(model);
        }
    }
}

// namespace ToDoList.Controllers
// {
//   public class ItemsController : Controller
//   {

//     [HttpGet("/categories/{categoryId}/items/new")]
//     public ActionResult New(int categoryId)
//     {
//       Category category = Category.Find(categoryId);
//       return View(category);
//     }

//     [HttpPost("/items/delete")]
//     public ActionResult DeleteAll()
//     {
//       Item.ClearAll();
//       return View();
//     }

//     [HttpGet("/categories/{categoryId}/items/{itemId}")]
//     public ActionResult Show(int categoryId, int itemId)
//     {
//       Item item = Item.Find(itemId);
//       Category category = Category.Find(categoryId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("item", item);
//       model.Add("category", category);
//       return View(model);
//     }
//   }
// }