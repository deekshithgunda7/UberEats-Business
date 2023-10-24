using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using UberEats.Models;
using UberEats.Models.DataLayer;

namespace UberEats.Controllers
{
    public class PartnerController : Controller
    {
        public readonly UberEatsContext _context;

        public PartnerController (UberEatsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Partners(int? ID)
        {
            List<Category> categories = _context.Categories.ToList();
            viewModel view = new viewModel
            {
                categories = categories
            };

            if (ID == null)
            {
                view.partners = new Partners();

                ViewBag.btnVal = "Add";
            }
            else
            {
                view.partners = _context.Partners.Where(x => x.ID == ID).FirstOrDefault();
                ViewBag.btnVal = "Update";
            }

            return View(view);
        }

        public IActionResult AddEditPartners(Partners partners)
        {
            if (ModelState.IsValid)
            {
                if (partners.ID == 0)
                {
                    partners.StatusID = 1;
                    _context.Partners.Add(partners);
                    _context.SaveChanges();
                    TempData["AUPartnerSuccess1"] = "Partner application for " + partners.BusinessName + " has been received. we will email once the application is approved.";
                    return RedirectToAction("Partners", "Admin");

                }
                else
                {
                    var partner = _context.Partners.Where(x => x.ID == partners.ID).FirstOrDefault();
                    partner.BusinessName = partners.BusinessName;
                    partner.BusinessEmail = partners.BusinessEmail;
                    partner.BusinessAddress = partners.BusinessAddress;
                    partner.Phone = partners.Phone;
                    partner.categoryID = partners.categoryID;
                    _context.SaveChanges();
                    TempData["AUPartnerSuccess1"] = "Partner application for " + partners.BusinessName + " has been updated.";
                    return RedirectToAction("Partners", "Admin");
                }
            }
            else
            {
                viewModel view = new viewModel();
                view.categories = _context.Categories.ToList();
                view.partners = partners;
                if (partners.ID == 0)
                {
                    ViewBag.btnVal = "Add";
                }
                else
                {
                    ViewBag.btnVal = "Update";
                }
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return View("Partners", view);
            }
        }
    }
}
