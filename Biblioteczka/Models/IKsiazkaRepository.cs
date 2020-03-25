using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models
{
    public interface IKsiazkaRepository
    {
        IQueryable<Ksiazki> Ksiazkis { get; }
        void SaveKsiazki(Ksiazki ksiazki);
        Ksiazki DeleteKsiazki(int ksiazkaID);
    }
}
