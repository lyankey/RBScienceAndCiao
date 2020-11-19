using ScienceAndCiao.Data;
using ScienceAndCiao.Models;
using ScienceAndCiao.Models.Admin;
using ScienceAndCiaoWebMVC.Data;
using ScienceAndCiaoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScienceAndCiaoWebMVC.Controllers
{
    public class KitController : Controller
    {
        private ApplicationDbContext _context;

        public KitController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageKits))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageKits)]
        public ViewResult New()
        {
            var branches = _context.Branches.ToList();

            var viewModel = new KitFormViewModel
            {
                Branches = branches
            };

            return View("KitForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageKits)]
        public ActionResult Edit(int id)
        {
            var kit = _context.Kits.SingleOrDefault(c => c.Id == id);

            if (kit == null)
                return HttpNotFound();

            var viewModel = new KitFormViewModel(kit)
            {
                Branches = _context.Branches.ToList()
            };

            return View("KitForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var kit = _context.Kits.Include(k => k.Description).SingleOrDefault(k => k.Id == id);

            if (kit == null)
                return HttpNotFound();

            return View(kit);

        }


        // GET: Kits/Random
        public ActionResult Random()
        {
            var kit = new Kit() { Name = "Cake" };
            var members = new List<Member>
            {
                new Member { Name = "Member 1" },
                new Member { Name = "Member 2" }
            };

            var viewModel = new RandomKitViewModel
            {
                Kit = kit,
                Members = members
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageKits)]
        public ActionResult Save(Kit kit)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new KitFormViewModel(kit)
                {
                    Branches = _context.Branches.ToList()
                };

                return View("KitForm", viewModel);
            }

            if (kit.Id == 0)
            {
                kit.DateAdded = DateTime.Now;
                _context.Kits.Add(kit);
            }
            else
            {
                var kitInDb = _context.Kits.Single(m => m.Id == kit.Id);
                kitInDb.Name = kit.Name;
                kitInDb.BranchId = kit.BranchId;
                kitInDb.DateAdded = kit.DateAdded;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Kits");
        }
    }
}