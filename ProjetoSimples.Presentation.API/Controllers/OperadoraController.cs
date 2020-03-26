using AutoMapper;
using ProjetoSimples.Domain.DomainEntities;
using ProjetoSimples.Domain.DomainServices;
using ProjetoSimples.Presentation.API.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjetoSimples.Presentation.API.Controllers
{
    [EnableCors(origins: "http://localhost:55348", headers: "*", methods: "*")]
    [RoutePrefix("api/operadora")]
    public class OperadoraController : ApiController
    {
        private readonly OperadoraDomainService _operadoraDomainService;

        public OperadoraController(OperadoraDomainService operadoraDomainService)
        {
            _operadoraDomainService = operadoraDomainService;
        }

        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage Get()
        {
            var lista = _operadoraDomainService.ObterTodos();
            if (lista == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nenhum registro encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        // GET: api/Operadora/5
        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage Obter(int id)
        {
            Operadora operadora = _operadoraDomainService.Obter(id);
            if (operadora == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nenhum registro encontrado");

            return Request.CreateResponse(HttpStatusCode.OK, operadora);
        }

        // POST: api/Operadora
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(OperadoraRequestModel operadoraRequestModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erros de validação");

            var operadora = Mapper.Map<OperadoraRequestModel, Operadora>(operadoraRequestModel);
            _operadoraDomainService.Cadastrar(operadora);

            return Request.CreateResponse(HttpStatusCode.OK, operadora);
            
        }

        // PUT: api/Operadora/5
        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Put(OperadoraRequestModel operadoraRequestModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erros de validação");

            var operadora = Mapper.Map<OperadoraRequestModel, Operadora>(operadoraRequestModel);
            _operadoraDomainService.Atualizar(operadora);

            return Request.CreateResponse(HttpStatusCode.OK, operadora);
        }

        // DELETE: api/Operadora/5
        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Delete(OperadoraRequestModel operadoraRequestModel)
        {
            if (operadoraRequestModel.Id.Equals(0) || operadoraRequestModel == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Favor informar o contato a ser excluído.");

            Operadora operadora = Mapper.Map<OperadoraRequestModel, Operadora>(operadoraRequestModel);
            _operadoraDomainService.Deletar(operadora);

            return Request.CreateResponse(HttpStatusCode.OK, "Operadora excluído com sucesso.");
        }
    }
}
