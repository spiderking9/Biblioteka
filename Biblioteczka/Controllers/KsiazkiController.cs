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
        public KsiazkiController(IKsiazkaRepository repo) => repository = repo;
        public ViewResult Lista()
        {
            return View(new ListaKsiazekViewModel { Ksiazkis = repository.Ksiazkis.Include(c => c.Categoria) });
        }

        public IActionResult Create()
        {
            KsiazkiCategorieViewModel ksiazkiCategorie = new KsiazkiCategorieViewModel(repository.Categorias.ToList());

            return View(ksiazkiCategorie);
        }

        [HttpPost]
        public ActionResult Create(KsiazkiCategorieViewModel ksiazkiCategorie)
        {
            if (ModelState.IsValid)
            {
                Categoria nowaKategoria = repository.Categorias.Single(c => c.Id == ksiazkiCategorie.CategoriaId);

                Ksiazki nowaKsiazka = new Ksiazki
                {
                    Tytul = ksiazkiCategorie.Tytul,
                    Autor = ksiazkiCategorie.Autor,
                    CzyDostepna = ksiazkiCategorie.CzyDostepna,
                    Categoria = nowaKategoria
                };

                repository.SaveKsiazki(nowaKsiazka);
                return RedirectToAction(nameof(Lista));
            }
            
            return View(ksiazkiCategorie);
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