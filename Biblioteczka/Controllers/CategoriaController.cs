using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteczka.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Biblioteczka.Models.ViewModels;

namespace Biblioteczka.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaRepository repository;

        public CategoriaController(ICategoriaRepository repo) => repository = repo;
        public ViewResult Lista()
        {
            return View(new ListaCategoriiViewModel { Categorias = repository.Categorias });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategoria(categoria);
                if (categoria != null)
                {
                    TempData["message"] = $"Dodano '{categoria.Nazwa}'.";
                }
                return RedirectToAction(nameof(Lista));
            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategoria(categoria);
                return RedirectToAction(nameof(Lista));
            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Delete(int categoriaId) //ten parametr jest przekazywany przez input name(to nazwa parametru ktora musi byc taka sama) value(to wartosc)
        {
            Categoria deletedCategoria = repository.DeleteCategoria(categoriaId);
            if (deletedCategoria != null)
            {
                TempData["message"] = $"Usunięto '{deletedCategoria.Nazwa}'.";
            }
            return RedirectToAction("Lista");
        }
    }
}