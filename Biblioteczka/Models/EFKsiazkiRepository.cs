using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models
{
    public class EFKsiazkiRepository : IKsiazkaRepository
    {
        private KsiazkiContext context;

        public EFKsiazkiRepository(KsiazkiContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Categoria> Categorias => context.Categorias;
        public IQueryable<Ksiazki> Ksiazkis => context.Ksiazkis;

        public void SaveKsiazki(Ksiazki ksiazki)
        {
            if (ksiazki.KsiazkaID == 0) //Sprawdzamy czy ma id, jezeli nie ma to znaczy ze mozna dodac ksiazke
            {
                context.Ksiazkis.Add(ksiazki);
            }
            else //jezeli ma id to wybieramy pozycje w bazie i eytujemy wszystkie pozycje
            {
                Ksiazki dbEntry = context.Ksiazkis.FirstOrDefault(p => p.KsiazkaID == ksiazki.KsiazkaID);
                if (dbEntry != null)
                {
                    dbEntry.Tytul = ksiazki.Tytul;
                    dbEntry.Autor = ksiazki.Autor;
                    dbEntry.Categoria = ksiazki.Categoria;
                    dbEntry.CzyDostepna = ksiazki.CzyDostepna;
                }
            }
            context.SaveChanges();
        }

        public Ksiazki DeleteKsiazki(int ksiazkaId)
        {
            Ksiazki dbEntry = context.Ksiazkis.FirstOrDefault(p => p.KsiazkaID == ksiazkaId);
            if (dbEntry != null)
            {
                context.Ksiazkis.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
