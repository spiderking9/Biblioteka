using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models
{
    public class Ksiazki
    {
        [Key]
        public int KsiazkaID { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł.")]
        public string Tytul { get; set; }
        [Required(ErrorMessage = "Proszę podać autora.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Proszę podać kategorie.")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public bool CzyDostepna { get; set; }
    }
}
