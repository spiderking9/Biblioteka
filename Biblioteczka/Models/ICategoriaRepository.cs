using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteczka.Models
{
    public interface ICategoriaRepository
    {
        IQueryable<Categoria> Categorias { get; }
        void SaveCategoria(Categoria categoria);
        Categoria DeleteCategoria(int id);
    }
}
