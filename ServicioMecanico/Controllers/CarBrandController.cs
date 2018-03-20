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
    public class CarBrandController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: CarBrand
        public ActionResult Index()
        {
            var model = unitOfWork.CarsBrandRepository.Queryable().ToList();
            return View(model);
        }

        // GET: CarBrand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarBrand/Create
        [HttpPost]
        public async Task<ActionResult> Create(CarBrand model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    // Car Brand create
                    unitOfWork.CarsBrandRepository.Create(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }

            return View(model);
        }

        // GET: CarBrand/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // Car Brand edit
            var model = await unitOfWork.CarsBrandRepository.FindAsync(id);
            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        // POST: CarBrand/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(CarBrand model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Car Brand edit
                    unitOfWork.CarsBrandRepository.Update(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //log errores
            }

            return View(model);
        }

        // GET: CarBrand/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            // Car Brand delete
            var model = await unitOfWork.CarsBrandRepository.FindAsync(id);
            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        // POST: CarBrand/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, CarBrand model)
        {
            try
            {
                // Car Brand delete
                await unitOfWork.CarsBrandRepository.Delete(id);
                await unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                //Log errors
            }

            return View();
        }
    }
}
