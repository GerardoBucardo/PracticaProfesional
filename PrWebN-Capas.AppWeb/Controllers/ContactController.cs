using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrWebN_Capas.BL;
using PrWebN_Capas.EN;

namespace PrWebN_Capas.AppWeb.Controllers
{
    public class ContactController : Controller
    {
        // GET: ContactController
        public async Task<ActionResult> Index()
        {
            var contact = await ContactBL.GetAll();
            return View(contact);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var contact = await ContactBL.GetById(id);
            return View(contact);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact pContact)
        {
            try
            {
                var result = await ContactBL.Create(pContact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var contact = await ContactBL.GetById(id);
            return View(contact);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Contact pContact)
        {
            try
            {
                var result = await ContactBL.Update(pContact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var contact = await ContactBL.GetById(id);
            return View(contact);

        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Contact pContact)
        {
            try
            {
                var result = await ContactBL.Delete(pContact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
