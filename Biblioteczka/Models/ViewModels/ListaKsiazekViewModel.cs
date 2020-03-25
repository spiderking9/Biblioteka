using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models.ViewModels
{
    public class ListaKsiazekViewModel
    {
        public IEnumerable<Ksiazki> Ksiazkis { get; set; }
    }
}
