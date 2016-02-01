using System.Collections.Generic;
using System.Linq;
using Giusti.Restaurante.Model.Results;
using Giusti.Restaurante.Business.Library;
using Giusti.Restaurante.Data;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Business
{
    public class PedidoBusiness : BusinessBase
    {
        public Pedido RetornaPedido_Id(int id)
        {
            LimpaValidacao();
            Pedido RetornoAcao = null;
            if (IsValid())
            {
                using (PedidoData data = new PedidoData())
                {
                    RetornoAcao = data.RetornaPedido_Id(id);
                }
            }

            return RetornoAcao;
        }
        public IList<Pedido> RetornaPedidos()
        {
            LimpaValidacao();
            IList<Pedido> RetornoAcao = new List<Pedido>();
            if (IsValid())
            {
                using (PedidoData data = new PedidoData())
                {
                    RetornoAcao = data.RetornaPedidos();
                }
            }

            return RetornoAcao;
        }
        public void SalvaPedido(Pedido itemGravar)
        {
            LimpaValidacao();
            ValidateService(itemGravar);
            ValidaRegrasSalvar(itemGravar);
            if (IsValid())
            {
                using (PedidoData data = new PedidoData())
                {
                    data.SalvaPedido(itemGravar);
                    serviceResult = new ServiceResult();
                    serviceResult.Success = true;
                    serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Pedido_SalvaPedidoOK") });
                }
            }
        }
        public void ValidaRegrasSalvar(Pedido itemGravar)
        {

        }
        public void ValidaExistencia(Pedido itemGravar)
        {
            if (itemGravar == null)
            {
                serviceResult = new ServiceResult();
                serviceResult.Success = false;
                serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Pedido_NaoEncontrado") });
            }
        }
    }
}
