using InternetteTescil.Entities.Entities;
using InternetteTescil.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternetteTescil.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IService<Order> _serviceOrder;

        public OrderController(IService<Order> serviceOrder)
        {
            _serviceOrder = serviceOrder;
        }

        public async Task<IActionResult> SearchByOrderEmail(string email)
        {
            var model = await _serviceOrder.GetAllAsync(p => p.OrderEMail== email);
            return View(model);
        }

        public async Task<ActionResult> Index()
        {
            var model = await _serviceOrder.GetAllAsync();
            return View(model);
        }
             
       
        public async Task<ActionResult> Create()
        {
            ViewBag.CustomerId = new SelectList(await _serviceOrder.GetAllAsync(), "CustomerId", "Name");
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _serviceOrder.Add(order);
                    _serviceOrder.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }

            }

            return View(order);
        }

       
        public ActionResult Edit(int id)
        {
            var model = _serviceOrder.Find(id);
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Order order)
        {
            try
            {
                _serviceOrder.Update(order);
                _serviceOrder.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            var model = _serviceOrder.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                _serviceOrder.Delete(order);
                _serviceOrder.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
