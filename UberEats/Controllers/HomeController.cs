using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UberEats.Models;
using UberEats.Models.DataLayer;

namespace UberEats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly UberEatsContext _context;
        public HomeController(ILogger<HomeController> logger, UberEatsContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Models.Partners partner = _context?.Partners?
                    .Where(x => x.BusinessEmail == model.Email)
                    .Include(x => x.Category)
                    .Include(x=>x.Status)
                    .FirstOrDefault();
                if (partner == null)
                {
                    ModelState.AddModelError("Email", "Invalid Partner Email");
                    return View(model);
                }
                TempData["partneremail"] = model.Email;
                return View("Partner", partner);
            }
            return View(model);
        }

        public IActionResult Partners(int? id)
        {
            List<Partners> partners;
            partners = _context.Partners
    .Where(x => x.Status.Name == "approved")
    .Include(x => x.Status)
    .Include(x => x.Category)
    .Select(x => new Partners
    {
        BusinessName = x.BusinessName,
        BusinessAddress = x.BusinessAddress,
        BusinessEmail = x.BusinessEmail,
        Phone = x.Phone,
        ID = x.ID

    })
    .ToList();

            viewModel view = new viewModel();
            view.Partners = partners;
            view.categories = _context.Categories.ToList();
            return View(view);
        }
        public IActionResult AddPartner()
        {
            List<Category> categories = _context.Categories.ToList();
            viewModel view = new viewModel
            {
                categories = categories
            };

            return View(view);
        }
        public IActionResult SavePartners(Partners partners)
        {
            if (ModelState.IsValid)
            {

                partners.StatusID = 1;
                _context.Partners.Add(partners);
                _context.SaveChanges();
                TempData["AUPartnerSuccess1"] = "Partner application for " + partners.BusinessName + " has been received. we will email once the application is approved.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                viewModel view = new viewModel();
                view.categories = _context.Categories.ToList();
                view.partners = partners;
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return View("Partners", view);
            }
        }
        public IActionResult AddFavorites(int? ID)
        {
            HttpContext.Session.SetString("ID", ID.ToString());
            var cookieoptions = new CookieOptions();
            cookieoptions.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Append("FavoriteID", ID.ToString(), cookieoptions);
            return RedirectToAction("Partners", "Home");
        }
        public IActionResult MyFavoriteStores(int ID)
        {
            ID = (int)TempData["PartnerID"];
            List<Partners> pp = _context.Partners
              .Where(x => x.ID == ID)
              .ToList();
            viewModel view = new viewModel();
            view.Partners = pp;
            view.categories = _context.Categories.ToList();
            return View(view);


        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ClearFavorites(int ID)
        {
            ID = (int)TempData["PartnerID"];
            TempData.Keep();
            List<Partners> sessionList = HttpContext.Session.GetObject<List<Partners>>("FavoriteStores");
            int count = HttpContext.Session.GetInt32("FavCount").HasValue ? (HttpContext.Session.GetInt32("FavCount")).Value : 0;

            List<Partners> partners;
            partners = _context.Partners
              .Where(x => x.ID == ID && x.Status.Name == "approved")
              .Include(x => x.Status)
              .Include(x => x.Category)
              .ToList();
            if (sessionList.Count > 0)
            {
                sessionList.RemoveAt(sessionList.Count - 1);
            }
            HttpContext.Session.SetObject("FavoriteStores", sessionList);
            count = sessionList.Count;
            TempData["FavCount"] = count;
            HttpContext.Session.SetInt32("FavCount", count);
            TempData["PartnerID"] = ID;
            TempData.Keep();
            return RedirectToAction("Partners", ID);



            //return RedirectToAction("Index");        
        }
        public IActionResult Detail_Partners(int? id)
        {
            List<Category> categories = _context.Categories.ToList();
            viewModel view = new viewModel
            {
                categories = categories
            };
            view.partners = _context.Partners.Include(x => x.Category).Where(x => x.ID == id).FirstOrDefault();
            return View(view);

        }

        public IActionResult AddDrivers()
        {
            return View();
        }

        public IActionResult SaveDriver(Driver driver)
        {
            driver.StatusID = 1;
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string Email, int Id)
        {
            bool exis = _context.Drivers.Any(x => x.Email == Email);
            if (exis)
                return Json(data: false);
            else
                return Json(data: true);


        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckAge(string DOB)
        {
            int age = 0;
            age = DateTime.Now.Subtract(Convert.ToDateTime(DOB)).Days;
            age = age / 365;
            if (age >= 18)
            {
                return Json(data: true);

            }
            return Json(data: false);


        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}