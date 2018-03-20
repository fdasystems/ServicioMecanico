using Data;
using ServicioMecanico.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServicioMecanico.Controllers
{
    [Authorize]
    public class OwnerController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Owner
        public ActionResult Index()
        {
            var model = unitOfWork.OwnersRepository.Queryable().ToList();
            return View(model);
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public async Task<ActionResult> Create(Owner model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    // Car Brand create
                    unitOfWork.OwnersRepository.Create(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }

            return View(model);
        }

        // GET: Owner/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // Owner edit
            var model = await unitOfWork.OwnersRepository.FindAsync(id);
            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Owner model)
        {
            try
            {
                if (ModelState.IsValid) 
                {   // Owner edit
                    unitOfWork.OwnersRepository.Update(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                } 
                
            }
            catch (Exception ex)
            {
                //log errors
            }

            return View(model);
        }

        // GET: Owner/Delete/5
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            // Owner delete
            var model = await unitOfWork.OwnersRepository.FindAsync(id);
            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        // POST: Owner/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Owner model)
        {
            try
            {
                // Owner delete
                await unitOfWork.OwnersRepository.Delete(id);
                await unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //log errors ex

            }

            return View();
        }
    }
}
