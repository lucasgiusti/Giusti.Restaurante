using System;
using System.Linq;
using Giusti.Restaurante.Model.Results;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Giusti.Restaurante.Model;
using Giusti.Restaurante.Data;

namespace Giusti.Restaurante.Business.Library
{
    public abstract class BusinessBase
    {
        #region Validacao

        public ServiceResult serviceResult = new ServiceResult();
        protected void ValidateService(object entity)
        {
            ValidationFactory.ResetCaches();
            Validator validator = ValidationFactory.CreateValidator(entity.GetType());
            ValidationResults results = validator.Validate(entity);
            AddValidationResults(results);
        }
        protected virtual void AddValidationResults(ValidationResults results)
        {
            foreach (ValidationResult result in results)
            {
                serviceResult.Messages.Add(new ServiceResultMessage() { Message = result.Message });
                serviceResult.Success = false;
            }
        }
        protected void LimpaValidacao()
        {
            serviceResult = new ServiceResult();
        }
        public bool IsValid()
        {
            return serviceResult.Success;
        }
        public void IncluiErro(string codigoMensagemErro)
        {
            IncluiErroBusiness(codigoMensagemErro, false);
        }
        protected void IncluiErroBusiness(string codigoMensagemErro)
        {
            IncluiErroBusiness(codigoMensagemErro, false);
        }
        protected void IncluiErroBusiness(string codigoMensagemErro, bool mensagemPersonalizada)
        {
            if (mensagemPersonalizada)
                IncluiMensagemErroBusiness(codigoMensagemErro);
            else
                IncluiMensagemErroBusiness(MensagemBusiness.RetornaMensagens(codigoMensagemErro));
        }
        protected void IncluiMensagemErroBusiness(string mensagemErro)
        {
            serviceResult = new ServiceResult();
            serviceResult.Success = false;
            serviceResult.Messages.Add(new ServiceResultMessage() { Message = mensagemErro });
        }

        #endregion
    }
}
