using CodeFirst_ContactManagement_Assignment.Models;
using CodeFirst_ContactManagement_Assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace CodeFirst_ContactManagement_Assignment.Controllers
{
    public class ContactsController : Controller
    {
        IContactRepository repo = new ContactRepository();
        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            return View(await repo.GetAllAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repo.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}