using InternetteTescil.Entities.Entities;
using InternetteTescil.Service.Abstract;
using InternetteTescil.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetteTescil.WebUI.Controllers
{
    public class CostumerController : Controller
    {
        private readonly IService<Costumer> _serviceCostumer;
        private readonly ICostumerService _costumterService;

        public CostumerController(IService<Costumer> serviceCostumer, ICostumerService costumterService)
        {
            _serviceCostumer = serviceCostumer;
            _costumterService = costumterService;
        }


        public async Task<ActionResult> CostumersByOrders()
        {
            var model = await _costumterService.GetAllCostumerByOrdersAsync();
            return View();

        }

        public async Task<IActionResult> SearchByName(string q)
        {
            var model = await _serviceCostumer.GetAllAsync(p=>p.Name.Contains(q));
            return View(model);
        }


        public async Task<IActionResult> SearchByTaxNo(string taxno)
        {
            var model = await _serviceCostumer.GetAllAsync(p => p.Taxno == taxno);
            return View(model);
        }

        public async Task<IActionResult> SearchByTaxCity(string city)
        {
            var model = await _serviceCostumer.GetAllAsync(p => p.City==city);
            return View(model);
        }

        public async Task<IActionResult> SearchByTaxEmail(string email)
        {
            var model = await _serviceCostumer.GetAllAsync(p => p.Email==email);
            return View(model);
        }


        public async Task<ActionResult> Index()
        {
            var model = await _serviceCostumer.GetAllAsync();
            return View(model);
           
        }

   
        public ActionResult Create()
        {
            return View();
        }

        // POST: CostumerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Costumer costumer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _serviceCostumer.Add(costumer);
                    _serviceCostumer.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }

            }

            return View(costumer);
        }

        public ActionResult Edit(int id)
        {
            var model = _serviceCostumer.Find(id);
            return View(model);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Costumer costumer)
        {
            try
            {
                _serviceCostumer.Update(costumer);
                _serviceCostumer.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            var model = _serviceCostumer.Find(id);
            return View(model);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Costumer costumer)
        {
            try
            {
                _serviceCostumer.Delete(costumer);
                _serviceCostumer.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
