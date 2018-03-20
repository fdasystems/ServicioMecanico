using Data;
using ServicioMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ServicioMecanico.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Service
         public ActionResult Index()
        {
            var model = unitOfWork.ServicesRepository.Queryable().ToList();
            return View(model);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public async Task<ActionResult> Create(Service model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    // Service create
                    unitOfWork.ServicesRepository.Create(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }

            return View(model);
        }

        // GET: Service/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // Service edit
            var model = await unitOfWork.ServicesRepository.FindAsync(id);
            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Service model)
        {
            try
            {
                if (ModelState.IsValid)
                {   // Service edit
                    unitOfWork.ServicesRepository.Update(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                } 

            }
            catch (Exception ex)
            {
                //log Errors
            }
            return View(model);
        }

        // GET: Service/Delete/5
        
        public async Task<ActionResult> Delete(int id)
        {
            // Service delete
            var model = await unitOfWork.ServicesRepository.FindAsync(id);
            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Service model)
        {
            try
            {

                // Service delete
                await unitOfWork.ServicesRepository.Delete(id);
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
