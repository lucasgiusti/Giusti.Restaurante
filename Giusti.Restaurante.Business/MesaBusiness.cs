using System.Collections.Generic;
using System.Linq;
using Giusti.Restaurante.Model.Results;
using Giusti.Restaurante.Business.Library;
using Giusti.Restaurante.Data;
using Giusti.Restaurante.Model;
using Giusti.Restaurante.Model.Dominio;

namespace Giusti.Restaurante.Business
{
    public class MesaBusiness : BusinessBase
    {
        public Mesa RetornaMesa_Id(int id)
        {
            LimpaValidacao();
            Mesa RetornoAcao = null;
            if (IsValid())
            {
                using (MesaData data = new MesaData())
                {
                    RetornoAcao = data.RetornaMesa_Id(id);
                }
            }

            return RetornoAcao;
        }
        public IList<Mesa> RetornaMesas()
        {
            LimpaValidacao();
            IList<Mesa> RetornoAcao = new List<Mesa>();
            if (IsValid())
            {
                using (MesaData data = new MesaData())
                {
                    RetornoAcao = data.RetornaMesas();
                }
            }

            return RetornoAcao;
        }
        public void SalvaMesa(Mesa itemGravar)
        {
            LimpaValidacao();
            ValidateService(itemGravar);
            ValidaRegrasSalvar(itemGravar);
            if (IsValid())
            {
                using (MesaData data = new MesaData())
                {
                    data.SalvaMesa(itemGravar);
                    serviceResult = new ServiceResult();
                    serviceResult.Success = true;
                    serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Mesa_SalvaMesaOK") });
                }
            }
        }

        public void ValidaRegrasSalvar(Mesa itemGravar)
        {
            if (itemGravar.Situacao == (int)enumSituacaoMesa.Fechada)
                itemGravar.Pedidos.FirstOrDefault().ValorTotal = itemGravar.Pedidos.FirstOrDefault().PedidoPratos.Where(a => a.Situacao != (int)enumSituacaoPedidoPrato.Cancelado).Sum(a => a.Prato.Preco);
        }
        public void ValidaExistencia(Mesa itemGravar)
        {
            if (itemGravar == null)
            {
                serviceResult = new ServiceResult();
                serviceResult.Success = false;
                serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Mesa_NaoEncontrada") });
            }
        }
    }
}
