using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giusti.Restaurante.Model
{
    public class PedidoPrato
    {
        public int? Id { get; set; }
        public int? PedidoId { get; set; }
        public int? PratoId { get; set; }
        public int? Situacao { get; set; }
        public string Opcoes { get; set; }
        public Pedido Pedido { get; set; }
        public Prato Prato { get; set; }
    }
}
