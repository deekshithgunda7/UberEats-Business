using Microsoft.AspNetCore.Mvc;
using UberEats.Models;
using UberEats.Models.DataLayer;
using UberEats.Models.DataLayer.Repositories;

namespace UberEats.Controllers
{
    public class MenuController : Controller
    {
        private Repository<MenuItem> menurepo { get; set; }
        private Repository<Partners> partnerrepo { get; set; }
        private Repository<MenuCategory> menucatrepo { get; set; }
        private Repository<MenuItem> menuitemrepo { get; set; }

        public MenuController(UberEatsContext ctx)
        {
            menurepo = new Repository<MenuItem>(ctx);
            partnerrepo = new Repository<Partners>(ctx);
            menucatrepo = new Repository<MenuCategory>(ctx);
            menuitemrepo = new Repository<MenuItem>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("List");


        public IActionResult List(int id, int menuid = 0)
        {
            MenuListViewModel model = new MenuListViewModel();
            model.Partner = partnerrepo.Get(id)?.BusinessName;
            model.PartnerId = id;
            model.ActiveMenuCategory = menuid;
            model.MenuCategories = menucatrepo.List(new QueryOptions<MenuCategory>
            { OrderBy = a => a.Id }).ToList();
            if (menuid == 0)
            {
                model.Data = menurepo.List(new QueryOptions<MenuItem>
                {
                    OrderBy = a => a.Id,
                    Includes = "MenuCategory",
                    Where = a => a.PartnerId == id
                }).ToList();
            }
            else
            {
                model.Data = menurepo.List(new QueryOptions<MenuItem>
                {
                    OrderBy = a => a.Id,
                    Includes = "MenuCategory",
                    Where = a => a.PartnerId == id && a.MenuCategoryId == menuid
                }).ToList();
            }

            return View(model);
        }

        public IActionResult Add(int id)
        {
            ViewBag.MenuCategories = menucatrepo.List(new QueryOptions<MenuCategory>
            { OrderBy = a => a.Id }).ToList();
            return View(new MenuItem { PartnerId = id });
        }

        [HttpPost]
        public IActionResult Add(MenuItem model)
        {
            int partnerid = model.Id;
            if (ModelState.IsValid)
            {
                model.Id = 0;
                menuitemrepo.Insert(model);
                menucatrepo.Save();
                return RedirectToAction("List", new { id = partnerid });
            }
            ViewBag.MenuCategories = menucatrepo.List(new QueryOptions<MenuCategory>
            { OrderBy = a => a.Id }).ToList();
            return View(model);
        }

        public IActionResult Update(int id,int partnerid)
        {
            ViewBag.MenuCategories = menucatrepo.List(new QueryOptions<MenuCategory>
            { OrderBy = a => a.Id }).ToList();
            var menuitem = menuitemrepo.Get(id);
            return View(menuitem);
        }

        [HttpPost]
        public IActionResult Update(MenuItem model)
        {
            if (ModelState.IsValid)
            {
                menuitemrepo.Update(model);
                menucatrepo.Save();
                return RedirectToAction("List", new { id = model.PartnerId });
            }
            ViewBag.MenuCategories = menucatrepo.List(new QueryOptions<MenuCategory>
            { OrderBy = a => a.Id }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id, int partnerid)
        {
            var menuitem = menuitemrepo.Get(id);
            menuitemrepo.Delete(menuitem);
            menucatrepo.Save();
            return RedirectToAction("List", new { id = partnerid });
        }
    }
}
