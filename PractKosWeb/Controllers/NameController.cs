using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class NameController : Controller
    {
        // GET: NameController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
