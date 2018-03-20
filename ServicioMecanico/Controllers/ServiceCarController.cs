using Data;
using ServicioMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace ServicioMecanico.Controllers
{
    [Authorize]
    public class ServiceCarController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();



        private List<SelectListItem> GetCarList()
        {
            return unitOfWork.CarsRepository.Queryable()
              .Select(e => new SelectListItem
              {
                  Value = e.IdCar.ToString(),
                  Text = e.CarBrand.Description + " (" + e.LicensePlate + ")"
              })
             .ToList();
        }

        private List<SelectListItem> GetCarList(int IdOwner)
        {
            return unitOfWork.CarsRepository.Queryable().Where(x=>x.IdOwner==IdOwner)
              .Select(e => new SelectListItem
              {
                  Value = e.IdCar.ToString(),
                  Text = e.CarBrand.Description + " (" + e.LicensePlate + ")"
              })
             .ToList();
        }

        public JsonResult GetCarListJson(int idOwner)
        {
            List<SelectListItem> result = GetCarList(idOwner);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetServiceList()
        {
            return unitOfWork.ServicesRepository.Queryable()
              .Select(e => new SelectListItem
              {
                  Value = e.IdService.ToString(),
                  Text = e.Description
              })
             .ToList();
        }

        private List<SelectListItem> GetServicePriceList(int idService)
        {
            return unitOfWork.ServicesRepository.Queryable().Where(x=>x.IdService==idService)
              .Select(e => new SelectListItem
              {
                  Value = e.IdService.ToString(),
                  Text = e.Price.ToString()
              })
             .ToList();
        }

        public JsonResult GetServicePriceListJson(int idService)
        {
            List<SelectListItem> result = GetServicePriceList(idService);
            return Json(result, JsonRequestBehavior.AllowGet);
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

        private List<SelectListItem> GetOwnerList(int idOwner)
        {
            return unitOfWork.OwnersRepository.Queryable().Where(x=>x.IdOwner==idOwner)
              .Select(e => new SelectListItem
              {
                  Value = e.IdOwner.ToString(),
                  Text = e.Name + " " + e.LastName
              })
             .ToList();
        }


        private ServicesCar MapperCarServiceVm2Model(ServiceCarViewModel viewModel)
        {
            ServicesCar Model = Mapper.Map<ServiceCarViewModel, ServicesCar>(viewModel);
            return Model;
        }

        private ServiceCarViewModel MapperCarServiceModel2Vm(ServicesCar model)
        {
            ServiceCarViewModel ViewModel = Mapper.Map<ServicesCar, ServiceCarViewModel>(model);
            return ViewModel;
        }

        // GET: ServiceCar
        public ActionResult Index()
        {
            var model = unitOfWork.ServicesCarRepository.Queryable().ToList();
            return View(model);
        }

        // GET: ServiceCar/Create
        public ActionResult Create()
        {
            ViewBag.ServiceList = new SelectList(GetServiceList(), "Value", "Text");
            ViewBag.OwnerList = new SelectList(GetOwnerList(), "Value", "Text");
            return View();
        }

        // POST: ServiceCar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServiceCarViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicesCar model = MapperCarServiceVm2Model(viewModel);

                    unitOfWork.ServicesCarRepository.Create(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }

            return View(viewModel);
        }



        // GET: ServiceCar/Edit/5

        public async Task<ActionResult> Edit(int id)
        {
            // ServiceCar edit
            var model = await unitOfWork.ServicesCarRepository.FindAsync(id);
            if (model != null)
            {
                ServiceCarViewModel viewModel = MapperCarServiceModel2Vm(model);
                viewModel.CarList = GetCarList(model.Car.IdOwner ?? 0);
                viewModel.OwnerList = GetOwnerList(model.Car.IdOwner ?? 0);
                viewModel.ServiceList = GetServiceList();
                return View(viewModel);
            }

            return View();
        }

        // POST: ServiceCar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ServiceCarViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {   // ServiceCar edit
                    ServicesCar model = MapperCarServiceVm2Model(viewModel);
                    ViewBag.ServiceList = new SelectList(GetServiceList(), "Value", "Text");
                    ViewBag.OwnerList = new SelectList(GetOwnerList(), "Value", "Text");
                    unitOfWork.ServicesCarRepository.Update(model);
                    await unitOfWork.SaveChangesAsync();
                    return RedirectToAction("Index");
                } 

            }
            catch (Exception ex)
            {
                //log error
            }

            return View(viewModel);

        }

        // GET: ServiceCar/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            // ServiceCar delete
            var model = await unitOfWork.ServicesCarRepository.FindAsync(id);
            if (model != null)
            {
                ServiceCarViewModel viewModel = MapperCarServiceModel2Vm(model);
                return View(viewModel);
            }

            return View();
        }

        // POST: ServiceCar/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ServicesCar model)
        {
            try
            {
                // ServiceCar delete
                await unitOfWork.ServicesCarRepository.Delete(id);
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
