using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
    // [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        private ShopContext context;
        // private List<Category> categories;

        public ProductController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Add");
        }

        // [Route("[controller]/{id?}")]
        // public IActionResult List(string id = "All")
        // {
        //     var categories = context.Categories
        //         .OrderBy(c => c.CategoryID).ToList();

        //     List<Product> products;
        //     if (id == "All")
        //     {
        //         products = context.Products
        //             .OrderBy(p => p.ProductID).ToList();
        //     }
        //     else
        //     {
        //         products = context.Products
        //             .Where(p => p.Category.Name == id)
        //             .OrderBy(p => p.ProductID).ToList();
        //     }

        //     // use ViewBag to pass data to view
        //     ViewBag.Categories = categories;
        //     ViewBag.SelectedCategoryName = id;

        //     // bind products to view
        //     return View(products);
        // }

        //   [HttpGet]
        // public IActionResult Add()
        // {
        //     // create new Product object
        //     Product product = new Product();                

        //     // use ViewBag to pass action and category data to view
        //     ViewBag.Action = "Add";
        //     ViewBag.Categories = categories;

        //     // bind product to AddUpdate view
        //     return View("Add", product);
        // }
        [Route("Product/Add")]
        [HttpGet]
        public IActionResult add()
        {
          return View();
        }

       [Route("Product/Add")]
        [HttpPost]
        public IActionResult add(Product product)
        {
           
              context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // [HttpGet]
        // public IActionResult Update(int id)
        // {
        //     // get Product object for specified primary key
        //     Product product = context.Products
        //         .Include(p => p.Category)
        //         .FirstOrDefault(p => p.ProductID == id) ?? new Product();

        //     // use ViewBag to pass action and category data to view
        //     ViewBag.Action = "Update";
        //     ViewBag.Categories = categories;

        //     // bind product to AddUpdate view
        //     return View("AddUpdate", product);
        // }

        // [HttpPost]
        // public IActionResult Add(Product product)
        // {
        //     //  if (ModelState.IsValid)
        //     //  {
        //     //     if (product.ProductID == 0)           // new product
        //     //      {
        //             context.Products.Add(product);
        //     //      }
        //     //      else                                  // existing product
        //     //  {
        //     //          context.Products.Update(product);
        //     //      }
        //         context.SaveChanges();
        //         return RedirectToAction("List");
        //     //  }
        // //  else
        // //      {
        // //         ViewBag.Action = "Save";
        // //          ViewBag.Categories = categories;
        // //          return View("Add", product);
        // //      }
        // }

        // // public IActionResult Details(int id)
        // // {
        // //     var categories = context.Categories
        // //         .OrderBy(c => c.CategoryID).ToList();

        // //     Product product = context.Products.Find(id) ?? new Product();

        // //     string imageFilename = product.BusinessName + "_m.png";

        // //     // use ViewBag to pass data to view
        // //     ViewBag.Categories = categories;
        //     ViewBag.ImageFilename = imageFilename;

        //     // bind product to view
        //     return View(product);
        // }
    }
}