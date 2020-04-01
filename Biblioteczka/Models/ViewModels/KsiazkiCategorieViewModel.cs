using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models.ViewModels
{
    public class KsiazkiCategorieViewModel
    {
        public int KsiazkaID { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł.")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Proszę podać autora.")]
        public string Autor { get; set; }

        public int CategoriaId { get; set; }
        public bool CzyDostepna { get; set; }

        public List<SelectListItem> Categorias { get; set; }
        public KsiazkiCategorieViewModel(IEnumerable<Categoria> categorias)
        {
            Categorias = new List<SelectListItem>();

            foreach (var cat in categorias)
            {
                Categorias.Add(new SelectListItem
                {
                    Value = cat.Id.ToString(),
                    Text = cat.Nazwa
                });
            }

            this.Categorias = Categorias;
        }
        public KsiazkiCategorieViewModel() { }
    }
}
