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

        public IQueryable<Ksiazki> Ksiazkis => context.Ksiazkis;

        public void SaveKsiazki(Ksiazki ksiazki)
        {
            if (ksiazki.KsiazkaID == 0)
            {
                context.Ksiazkis.Add(ksiazki);
            }
            else
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
