using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models
{
    public class EFCategoriaRepository : ICategoriaRepository
    {
        private KsiazkiContext context;

        public EFCategoriaRepository(KsiazkiContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Categoria> Categorias => context.Categorias;

        public IQueryable<Ksiazki> Ksiazkis => context.Ksiazkis;

        public void SaveCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                Categoria dbEntry = context.Categorias.FirstOrDefault(p => p.Id == categoria.Id);
                if (dbEntry != null)
                {
                    dbEntry.Nazwa = categoria.Nazwa;
                }
            }
            context.SaveChanges();

        }

        public Categoria DeleteCategoria(int categoriaId)
        {
            Categoria dbEntry = context.Categorias.FirstOrDefault(p => p.Id == categoriaId);
            if (dbEntry != null)
            {
                context.Categorias.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
