using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giusti.Restaurante.Model
{
    public class Pedido
    {
        public Pedido()
        {
            PedidoPratos = new List<PedidoPrato>();
        }

        public int? Id { get; set; }
        public int? MesaId { get; set; }
        public int? Situacao { get; set; }
        public double? ValorTotal { get; set; }
        public Mesa Mesa { get; set; }
        public IList<PedidoPrato> PedidoPratos { get; set; }
    }
}
