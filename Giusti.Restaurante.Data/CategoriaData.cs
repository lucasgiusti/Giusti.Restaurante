using System.Collections.Generic;
using System.Linq;
using System.Data;
using Giusti.Restaurante.Model;
using Giusti.Restaurante.Data.Library;

namespace Giusti.Restaurante.Data
{
    public class CategoriaData : DataBase
    {
        public Categoria RetornaCategoria_Id(int id)
        {
            IQueryable<Categoria> query = Context.Categorias;

            query = query.Where(d => d.Id == id);
            return query.FirstOrDefault();
        }
        public IList<Categoria> RetornaCategorias()
        {
            IQueryable<Categoria> query = Context.Categorias;

            return query.ToList();
        }
        public void SalvaCategoria(Categoria itemGravar)
        {
            Categoria itemBase = Context.Categorias.Where(f => f.Id == itemGravar.Id).FirstOrDefault();
            if (itemBase == null)
            {
                itemBase = Context.Categorias.Create();
                Context.Entry<Categoria>(itemBase).State = System.Data.Entity.EntityState.Added;
            }
            AtualizaPropriedades<Categoria>(itemBase, itemGravar);
            Context.SaveChanges();
            itemGravar.Id = itemBase.Id;
        }
        public void ExcluiCategoria(Categoria itemGravar)
        {
            Categoria itemExcluir = Context.Categorias.Where(f => f.Id == itemGravar.Id).FirstOrDefault();

            Context.Entry<Categoria>(itemExcluir).State = System.Data.Entity.EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
