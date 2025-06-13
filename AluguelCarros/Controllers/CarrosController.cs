using Microsoft.AspNetCore.Mvc;
using AluguelCarros.Models;
using AluguelCarros.Repositories;

namespace AluguelCarros.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ICarroRepository _repo;

        public CarrosController(ICarroRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var carros = _repo.GetAll();
            return View(carros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(carro);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        public IActionResult Edit(int id)
        {
            var carro = _repo.GetById(id);
            if (carro == null) return NotFound();
            return View(carro);
        }

        [HttpPost]
        public IActionResult Edit(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(carro);
                _repo.Save();
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction("Index");
        }
    }
}
