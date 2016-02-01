using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Giusti.Restaurante.Model;
using Giusti.Restaurante.Model.Dominio;
using Giusti.Restaurante.Data.Library;

namespace Giusti.Restaurante.Data
{
    public class MesaData : DataBase
    {
        public Mesa RetornaMesa_Id(int id)
        {
            IQueryable<Mesa> query = Context.Mesas.Include("Pedidos").Include("Pedidos.PedidoPratos").Include("Pedidos.PedidoPratos.Prato").Include("Pedidos.PedidoPratos.Prato.Categoria");

            query = query.Where(d => d.Id == id);
            return query.FirstOrDefault();
        }
        public IList<Mesa> RetornaMesas()
        {
            IQueryable<Mesa> query = Context.Mesas;

            return query.ToList();
        }
        public void SalvaMesa(Mesa itemGravar)
        {
            Mesa itemBase = Context.Mesas.Include("Pedidos").Include("Pedidos.PedidoPratos").Where(f => f.Id == itemGravar.Id).FirstOrDefault();
            if (itemBase == null)
            {
                itemBase = Context.Mesas.Create();
                Context.Entry<Mesa>(itemBase).State = System.Data.Entity.EntityState.Added;
            }
            AtualizaPropriedades<Mesa>(itemBase, itemGravar);

            foreach (Pedido itemPedido in new List<Pedido>(itemBase.Pedidos))
            {
                if (!itemGravar.Pedidos.Where(f => f.Id == itemPedido.Id).Any())
                {
                    foreach (PedidoPrato itemPedidoPrato in new List<PedidoPrato>(itemPedido.PedidoPratos))
                    {
                        Context.Entry<PedidoPrato>(itemPedidoPrato).State = System.Data.Entity.EntityState.Deleted;
                    }
                    Context.Entry<Pedido>(itemPedido).State = System.Data.Entity.EntityState.Deleted;
                }
            }

            foreach (Pedido itemPedido in new List<Pedido>(itemGravar.Pedidos))
            {
                Pedido itemBasePedido = !itemPedido.Id.HasValue ? null : itemBase.Pedidos.Where(f => f.Id == itemPedido.Id).FirstOrDefault();
                if (itemBasePedido == null)
                {
                    itemBasePedido = Context.Pedidos.Create();
                    itemBase.Pedidos.Add(itemBasePedido);
                }
                AtualizaPropriedades<Pedido>(itemBasePedido, itemPedido);

                foreach (PedidoPrato itemPedidoPrato in new List<PedidoPrato>(itemPedido.PedidoPratos))
                {
                    PedidoPrato itemBasePedidoPrato = !itemPedidoPrato.Id.HasValue ? null : itemBase.Pedidos.Select(f => f.PedidoPratos.Where(g => g.Id == itemPedidoPrato.Id).FirstOrDefault()).FirstOrDefault();
                    if (itemBasePedidoPrato == null)
                    {
                        itemBasePedidoPrato = Context.PedidoPratos.Create();
                        itemBase.Pedidos.FirstOrDefault().PedidoPratos.Add(itemBasePedidoPrato);
                    }
                    AtualizaPropriedades<PedidoPrato>(itemBasePedidoPrato, itemPedidoPrato);
                }
            }
            Context.SaveChanges();
            itemGravar.Id = itemBase.Id;
        }
    }
}
