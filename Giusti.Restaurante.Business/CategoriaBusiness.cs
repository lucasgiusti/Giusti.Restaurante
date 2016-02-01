using System.Collections.Generic;
using System.Linq;
using Giusti.Restaurante.Model.Results;
using Giusti.Restaurante.Business.Library;
using Giusti.Restaurante.Data;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Business
{
    public class CategoriaBusiness : BusinessBase
    {
        public Categoria RetornaCategoria_Id(int id)
        {
            LimpaValidacao();
            Categoria RetornoAcao = null;
            if (IsValid())
            {
                using (CategoriaData data = new CategoriaData())
                {
                    RetornoAcao = data.RetornaCategoria_Id(id);
                }
            }

            return RetornoAcao;
        }
        public IList<Categoria> RetornaCategorias()
        {
            LimpaValidacao();
            IList<Categoria> RetornoAcao = new List<Categoria>();
            if (IsValid())
            {
                using (CategoriaData data = new CategoriaData())
                {
                    RetornoAcao = data.RetornaCategorias();
                }
            }

            return RetornoAcao;
        }
        public void SalvaCategoria(Categoria itemGravar)
        {
            LimpaValidacao();
            ValidateService(itemGravar);
            ValidaRegrasSalvar(itemGravar);
            if (IsValid())
            {
                using (CategoriaData data = new CategoriaData())
                {
                    data.SalvaCategoria(itemGravar);
                    serviceResult = new ServiceResult();
                    serviceResult.Success = true;
                    serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Categoria_SalvaCategoriaOK") });
                }
            }
        }
        public void ExcluiCategoria(Categoria itemGravar)
        {
            LimpaValidacao();
            ValidateService(itemGravar);
            ValidaRegrasExcluir(itemGravar);
            if (IsValid())
            {
                using (CategoriaData data = new CategoriaData())
                {
                    data.ExcluiCategoria(itemGravar);
                    serviceResult = new ServiceResult();
                    serviceResult.Success = true;
                    serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Categoria_ExcluiCategoriaOK") });
                }
            }
        }

        public void ValidaRegrasSalvar(Categoria itemGravar)
        {

        }
        public void ValidaRegrasExcluir(Categoria itemGravar)
        {
            ValidaExistencia(itemGravar);
        }
        public void ValidaExistencia(Categoria itemGravar)
        {
            if (itemGravar == null)
            {
                serviceResult = new ServiceResult();
                serviceResult.Success = false;
                serviceResult.Messages.Add(new ServiceResultMessage() { Message = MensagemBusiness.RetornaMensagens("Categoria_NaoEncontrada") });
            }
        }
    }
}
