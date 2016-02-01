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
    /// Categoria
    /// </summary>
    public class CategoriaController : ApiBase
    {
        CategoriaBusiness biz = new CategoriaBusiness();

        /// <summary>
        /// Retorna todas as categorias
        /// </summary>
        /// <returns></returns>
        public List<Categoria> Get()
        {
            List<Categoria> ResultadoBusca = new List<Categoria>();
            try
            {
                //API
                ResultadoBusca = new List<Categoria>(biz.RetornaCategorias());

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