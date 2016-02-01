using System.Collections.Generic;
using System.Linq;
using Giusti.Restaurante.Model.Results;
using Giusti.Restaurante.Business.Library;
using Giusti.Restaurante.Data;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Business
{
    public class PratoBusiness : BusinessBase
    {
        public Prato RetornaPrato_Id(int id)
        {
            LimpaValidacao();
            Prato RetornoAcao = null;
            if (IsValid())
            {
                using (PratoData data = new PratoData())
                {
                    RetornoAcao = data.RetornaPrato_Id(id);
                }
            }

            return RetornoAcao;
        }
        public IList<Prato> RetornaPratos()
        {
            LimpaValidacao();
            IList<Prato> RetornoAcao = new List<Prato>();
            if (IsValid())
            {
                using (PratoData data = new PratoData())
                {
                    RetornoAcao = data.RetornaPratos();
                }
            }

            return RetornoAcao;
        }
        public void SalvaPrato(Prato itemGravar)
        {
            LimpaValidacao();
            ValidateService(itemGravar);
            ValidaRegrasSalvar(itemGravar);
            if (IsValid())
            {
                using (PratoData data = new PratoData())
                {
                    data.SalvaPrato(itemGravar);
                    serviceResult = new ServiceResult();
                    serviceResult.Success = true;
                    serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Prato_SalvaPratoOK") });
                }
            }
        }
        public void ExcluiPrato(Prato itemGravar)
        {
            LimpaValidacao();
            ValidateService(itemGravar);
            ValidaRegrasExcluir(itemGravar);
            if (IsValid())
            {
                using (PratoData data = new PratoData())
                {
                    data.ExcluiPrato(itemGravar);
                    serviceResult = new ServiceResult();
                    serviceResult.Success = true;
                    serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Prato_ExcluiPratoOK") });
                }
            }
        }

        public void ValidaRegrasSalvar(Prato itemGravar)
        {

        }
        public void ValidaRegrasExcluir(Prato itemGravar)
        {
            ValidaExistencia(itemGravar);
        }
        public void ValidaExistencia(Prato itemGravar)
        {
            if (itemGravar == null)
            {
                serviceResult = new ServiceResult();
                serviceResult.Success = false;
                serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Prato_NaoEncontrado") });
            }
        }
    }
}
