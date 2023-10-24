using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberEats.Models;
using UberEats.Models.DataLayer;

namespace UberEats.Controllers
{
    public class AdminController : Controller
    {
        public readonly UberEatsContext _context;

        public AdminController(UberEatsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Partners(int? id)
        {
            List<Partners> partners;
            if (id == 0 || id == null)
            {
               partners = _context.Partners.Include(x => x.Category).Include(x => x.Status).ToList();
            }
            else
            {
                 partners = _context.Partners.Where(x=>x.categoryID == id).Include(x => x.Status).Include(x=>x.Category).ToList();
            }
            viewModel view = new viewModel();
            view.Partners = partners;
            view.categories = _context.Categories.ToList();
            return View(view);
        }

      
        public IActionResult DeletePartner(int? ID)
        {
            var data = _context.Partners.Where(x => x.ID == ID).FirstOrDefault();
            TempData["PartnerName1"] = data.BusinessName;
            TempData["ID"] = data.ID;
            return View();
        }

        public IActionResult ConfirmDeletion(int? ID)
        {
            var data = _context.Partners.Where(x => x.ID == ID).FirstOrDefault();
            _context.Partners.Remove(data);
            _context.SaveChanges();
            TempData["DeleteSuccess"] = "Partner application for " + data.BusinessName + " has been removed.";
            return RedirectToAction("Partners", "Admin");
        }

        public IActionResult ApporvePartner(int? id)
        {
            var partner = _context.Partners.Where(x => x.ID == id).FirstOrDefault();
            TempData["Message1"] = "" + partner.BusinessName + " located at " + partner.BusinessAddress + " ";
            TempData["ID"] = partner.ID;
            return View();
        }

        public IActionResult AcceptPartner(int? id)
        {
            var partner = _context.Partners.Where(x => x.ID == id).FirstOrDefault();
            partner.StatusID = 2;
            _context.SaveChanges();
            TempData["Message1"] = "Partner application for "+partner.BusinessName+" has been approved. ";
            return RedirectToAction("Partners", "Admin");

        }
        public IActionResult RejectPartner(int? id)
        {
            var partner = _context.Partners.Where(x => x.ID == id).FirstOrDefault();
            partner.StatusID = 3;
            _context.SaveChanges();
            TempData["Message1"] = "Partner application for " + partner.BusinessName + " has been rejected. ";
            return RedirectToAction("Partners", "Admin");

        }

        public IActionResult Drivers(int? id)
        {
            var drivers = _context.Drivers.Include(x=>x.Status).ToList();
            return View(drivers);
        }

        public IActionResult ApproveDriver(int id)
        {
            var driver = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            TempData["DMessage"] = "" + driver.FirstName +""+driver.LastName + " located at " + driver.Address + " with SSN "+driver.SSN +" ";
            TempData["DID"] = driver.Id;
            return View();

        }

        public IActionResult AcceptDriver(int? id)
        {
            var driver = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            driver.StatusID = 2;
            _context.SaveChanges();
            TempData["Message1"] = "Partner application for " + driver.FirstName + " " + driver.LastName + " has been approved. ";
            return RedirectToAction("Drivers", "Admin");
        }
        public IActionResult RejectDriver(int? id)
        {
            var driver = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            driver.StatusID = 3;
            _context.SaveChanges();
            TempData["Message1"] = "Partner application for " + driver.FirstName + " " + driver.LastName + " has been rejected. ";
            return RedirectToAction("Drivers", "Admin");
        }

        public IActionResult DeleteDriver(int? id)
        {
            var data = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            TempData["DriverName"] = data.FirstName +" " + data.LastName;
            TempData["DID"] = data.Id;
            return View();
        }

        public IActionResult ConfirmDriverDeletion(int? id)
        {
            var data = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            _context.Drivers.Remove(data);
            _context.SaveChanges();
            TempData["Message1"] = "Partner application for " + data.FirstName + " " + data.LastName + " has been removed. ";
            return RedirectToAction("Drivers", "Admin");
        }

        public IActionResult AddDriver(int? id)
        {

            Driver driver;
            if (id == null)
            {
                driver = new Driver();
            }
            else
            {
                driver = _context.Drivers.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(driver);
        }

        public IActionResult SaveDriver(Driver driver)
        {
            if(driver.Id == 0)
            {
                driver.StatusID = 1;
                _context.Drivers.Add(driver);
            }
            else
            {
                var data = _context.Drivers.Where(x => x.Id == driver.Id).FirstOrDefault();
                data.FirstName = driver.FirstName;
                data.LastName = driver.LastName;
                data.DOB = driver.DOB;
                data.SSN = driver.SSN;
                data.DLNumber = driver.DLNumber;
                data.Email = driver.Email;
                data.Address = driver.Address;
                data.PostCode = driver.PostCode;
                data.Phone = driver.Phone;
                
            }
           
            _context.SaveChanges();
            return RedirectToAction("Drivers", "Admin");
        }
    }
}
