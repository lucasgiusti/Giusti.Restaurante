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
    /// Mesa
    /// </summary>
    public class MesaController : ApiBase
    {
        MesaBusiness biz = new MesaBusiness();

        /// <summary>
        /// Retorna todas as mesas
        /// </summary>
        /// <returns></returns>
        public List<Mesa> Get()
        {
            List<Mesa> ResultadoBusca = new List<Mesa>();
            try
            {
                //API
                ResultadoBusca = new List<Mesa>(biz.RetornaMesas());

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

        /// <summary>
        /// Retorna a mesa com id solicidado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mesa Get(int id)
        {
            Mesa ResultadoBusca = new Mesa();
            try
            {
                //API
                ResultadoBusca = biz.RetornaMesa_Id(id);

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

        /// <summary>
        /// Altera uma determinada mesa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemSalvar"></param>
        /// <returns></returns>
        public Mesa Put(int id, [FromBody]Mesa itemSalvar)
        {
            try
            {
                //API
                itemSalvar.Id = id;
                biz.SalvaMesa(itemSalvar);

                if (!biz.IsValid())
                    throw new InvalidDataException();

                itemSalvar = biz.RetornaMesa_Id(id);
            }
            catch (InvalidDataException)
            {
                GeraErro(HttpStatusCode.InternalServerError, biz.serviceResult);
            }
            catch (Exception ex)
            {
                GeraErro(HttpStatusCode.BadRequest, ex);
            }

            return itemSalvar;
        }
    }
}