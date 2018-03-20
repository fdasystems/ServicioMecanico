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
    public class CarController : Controller
    {

        private UnitOfWork unitOfWork = new UnitOfWork();

        private List<SelectListItem> GetCarBrandList()
        {
            return unitOfWork.CarsBrandRepository.Queryable()
              .Select(e => new SelectListItem
              {
                  Value = e.IdCarBrand.ToString(),
                  Text = e.Description
              })
             .ToList();
        }

        private List<SelectListItem> GetOwnerList()
        {
            return unitOfWork.OwnersRepository.Queryable()
              .Select(e => new SelectListItem
              {
                  Value = e.IdOwner.ToString(),
                  Text = e.Name + " " + e.LastName
              })
             .ToList();
        }

        // GET: CarService
        public ActionResult Index()
        {
            try
            {
                var data = unitOfWork.CarsRepository.Queryable().ToList();
                
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: CarService/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarService/Create
        public ActionResult Create()
        {
            ViewBag.CarBrandList = new SelectList(GetCarBrandList(), "Value", "Text");
            ViewBag.OwnerList = new SelectList(GetOwnerList(), "Value", "Text");
            return View();
        }

        // POST: CarService/Create
        [HttpPost]
        public async Task<ActionResult> Create(Car model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Create car
                    unitOfWork.CarsRepository.Create(model);
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

        // GET: Car/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            // Car Brand edit
            var model = await unitOfWork.CarsRepository.FindAsync(id);
            return View(model);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Car model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Car edit
                    unitOfWork.CarsRepository.Update(model);
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

        // GET: CarBrand/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            // Car Brand delete
            var model = await unitOfWork.CarsRepository.FindAsync(id);
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
                await unitOfWork.CarsRepository.Delete(id);
                await unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //log errors
            }

            return View();
        }
    }
}
