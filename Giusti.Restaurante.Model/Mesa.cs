using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giusti.Restaurante.Model
{
    public class Mesa
    {
        public Mesa() {
            Pedidos = new List<Pedido>();
        }

        public int? Id { get; set; }
        public int? Situacao { get; set; }
        public IList<Pedido> Pedidos { get; set; }
    }
}
