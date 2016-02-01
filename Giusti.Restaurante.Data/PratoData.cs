using System.Collections.Generic;
using System.Linq;
using System.Data;
using Giusti.Restaurante.Model;
using Giusti.Restaurante.Data.Library;

namespace Giusti.Restaurante.Data
{
    public class PratoData : DataBase
    {
        public Prato RetornaPrato_Id(int id)
        {
            IQueryable<Prato> query = Context.Pratos;

            query = query.Where(d => d.Id == id);
            return query.FirstOrDefault();
        }
        public IList<Prato> RetornaPratos()
        {
            IQueryable<Prato> query = Context.Pratos.Include("Categoria");
            query.OrderBy(a => a.Categoria.Id).ThenBy(a => a.Id);

            return query.ToList();
        }
        public void SalvaPrato(Prato itemGravar)
        {
            Prato itemBase = Context.Pratos.Where(f => f.Id == itemGravar.Id).FirstOrDefault();
            if (itemBase == null)
            {
                itemBase = Context.Pratos.Create();
                Context.Entry<Prato>(itemBase).State = System.Data.Entity.EntityState.Added;
            }
            AtualizaPropriedades<Prato>(itemBase, itemGravar);
            Context.SaveChanges();
            itemGravar.Id = itemBase.Id;
        }
        public void ExcluiPrato(Prato itemGravar)
        {
            Prato itemExcluir = Context.Pratos.Where(f => f.Id == itemGravar.Id).FirstOrDefault();

            Context.Entry<Prato>(itemExcluir).State = System.Data.Entity.EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
