using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteczka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biblioteczka.Models.ViewModels;

namespace Biblioteczka.Controllers
{
    public class KsiazkiController : Controller
    {
        private IKsiazkaRepository repository;
        public KsiazkiController(IKsiazkaRepository repo)
        {
            repository = repo;
        }
        public ViewResult Lista()
        {
            return View(new ListaKsiazekViewModel { Ksiazkis = repository.Ksiazkis });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ksiazki ksiazki)
        {
            if (ModelState.IsValid)
            {
                repository.SaveKsiazki(ksiazki);
                if (ksiazki != null)
                {
                    TempData["message"] = $"Dodano '{ksiazki.Tytul}'.";
                }
                return RedirectToAction(nameof(Lista));
            }
            return View(ksiazki);
        }

        public ViewResult Edit(int ksiazkaId) => View(repository.Ksiazkis.FirstOrDefault(ksiazka => ksiazka.KsiazkaID == ksiazkaId));


        [HttpPost]
        public IActionResult Edit(Ksiazki ksiazki)
        {
            if (ModelState.IsValid)
            {
                repository.SaveKsiazki(ksiazki);
                return RedirectToAction(nameof(Lista));
            }
            return View(ksiazki);
        }

        [HttpPost]
        public IActionResult Delete(int ksiazkaId) //ten parametr jest przekazywany przez input name(to nazwa parametru ktora musi byc taka sama) value(to wartosc)
        {
            Ksiazki deletedKsiazka = repository.DeleteKsiazki(ksiazkaId);
            if (deletedKsiazka != null)
            {
                TempData["message"] = $"Usunięto '{deletedKsiazka.Tytul}'.";
            }
            return RedirectToAction("Lista");
        }
    }
}