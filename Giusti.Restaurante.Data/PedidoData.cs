using System.Collections.Generic;
using System.Linq;
using System.Data;
using Giusti.Restaurante.Model;
using Giusti.Restaurante.Data.Library;

namespace Giusti.Restaurante.Data
{
    public class PedidoData : DataBase
    {
        public Pedido RetornaPedido_Id(int id)
        {
            IQueryable<Pedido> query = Context.Pedidos;

            query = query.Where(d => d.Id == id);
            return query.FirstOrDefault();
        }
        public IList<Pedido> RetornaPedidos()
        {
            IQueryable<Pedido> query = Context.Pedidos;

            return query.ToList();
        }
        public void SalvaPedido(Pedido itemGravar)
        {
            Pedido itemBase = Context.Pedidos.Where(f => f.Id == itemGravar.Id).FirstOrDefault();
            if (itemBase == null)
            {
                itemBase = Context.Pedidos.Create();
                Context.Entry<Pedido>(itemBase).State = System.Data.Entity.EntityState.Added;
            }
            AtualizaPropriedades<Pedido>(itemBase, itemGravar);
            Context.SaveChanges();
            itemGravar.Id = itemBase.Id;
        }
    }
}
