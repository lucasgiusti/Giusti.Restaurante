using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giusti.Restaurante.Model
{
    public class Prato
    {
        public int? Id { get; set; }
        public int? CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Opcoes { get; set; }
        public Categoria Categoria { get; set; }
        public IList<PedidoPrato> PedidoPratos { get; set; }
    }
}
