using Giusti.Restaurante.App.Library;
using Giusti.Restaurante.Business;
using Giusti.Restaurante.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Giusti.Restaurante.App.Controllers
{
    /// <summary>
    /// Prato
    /// </summary>
    public class PratoController : ApiBase
    {
        PratoBusiness biz = new PratoBusiness();

        /// <summary>
        /// Retorna todos os pratos
        /// </summary>
        /// <returns></returns>
        public List<Prato> Get()
        {
            List<Prato> ResultadoBusca = new List<Prato>();
            try
            {
                //API
                ResultadoBusca = new List<Prato>(biz.RetornaPratos());

                if (!biz.IsValid())
                    throw new InvalidDataException();
            }
            catch (InvalidDataException)
            {
                GeraErro(HttpStatusCode.InternalServerError, biz.serviceResult);
            }
            catch (Exception ex)
            {
                GeraErro(HttpStatusCode.BadRequest, ex);
            }

            return ResultadoBusca;
        }
    }
}