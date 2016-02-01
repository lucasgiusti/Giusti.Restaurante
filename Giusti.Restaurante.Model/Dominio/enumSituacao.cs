using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giusti.Restaurante.Model.Dominio
{
    public enum enumSituacaoMesa
    {
        Livre = 0,
        Aberta = 1,
        Fechada = 2
    }

    public enum enumSituacaoPedido
    {
        Aberto = 0,
        Fechado = 1,
        Finalizado = 2
    }

    public enum enumSituacaoPedidoPrato
    {
        Aguardando = 0,
        Entregue = 1,
        Cancelado = 2
    }

    public enum enumSituacaoPrato
    {
        Ativo = 0,
        Inativo = 1
    }
}
