using ScienceAndCiao.Data;
using ScienceAndCiaoWebMVC.Data;
using ScienceAndCiaoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScienceAndCiaoWebMVC.Controllers
{
    public class MemberController : Controller
    {
        private ApplicationDbContext _context;

        public MemberController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new MemberFormViewModel
            {
                Member = new Member(),
                MembershipTypes = membershipTypes
            };

            return View("MemberForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Member member)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MemberFormViewModel
                {
                    Member = member,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("MemberForm", viewModel);
            }

            if (member.Id == 0)
                _context.Members.Add(member);
            else
            {
                var memberInDb = _context.Members.Single(c => c.Id == member.Id);
                memberInDb.Name = member.Name;
                memberInDb.Birthdate = member.Birthdate;
                memberInDb.MembershipTypeId = member.MembershipTypeId;
                memberInDb.IsSubscribedToEmails = member.IsSubscribedToEmails;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Members");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var member = _context.Members.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (member == null)
                return HttpNotFound();

            return View(member);
        }

        public ActionResult Edit(int id)
        {
            var member = _context.Members.SingleOrDefault(c => c.Id == id);

            if (member == null)
                return HttpNotFound();

            var viewModel = new MemberFormViewModel
            {
                Member = member,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("MemberForm", viewModel);
        }
    }
}