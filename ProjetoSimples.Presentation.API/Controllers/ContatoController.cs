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
    //[DisableCors()]
    [RoutePrefix("api/contato")]
    public class ContatoController : ApiController
    {
        private readonly ContatoDomainService _contatoDomainService;

        public ContatoController(ContatoDomainService contatoDomainService)
        {
            _contatoDomainService = contatoDomainService;
        }

        [EnableCors(origins: "http://localhost:55348", headers: "*", methods: "*")]
        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage Get()
        {
        
            var lista = _contatoDomainService.ObterTodos();

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage Obter(int id)
        {
            var lista = _contatoDomainService.Obter(id);

            if (lista == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nenhum registro encontrado.");

            return Request.CreateResponse(HttpStatusCode.OK, lista);
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(ContatoRequestModel contatoRequestModel)
        {
            if(!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erros de validação");

            Contato contato = Mapper.Map<ContatoRequestModel, Contato>(contatoRequestModel);
            _contatoDomainService.Cadastrar(contato);

            return Request.CreateResponse(HttpStatusCode.OK, contato);
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Put(ContatoRequestModel contatoRequestModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erros de validação");

            Contato contato = Mapper.Map<ContatoRequestModel, Contato>(contatoRequestModel);
            _contatoDomainService.Atualizar(contato);

            return Request.CreateResponse(HttpStatusCode.OK, contato);
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Delete(ContatoRequestModel contatoRequestModel)
        {
            if (contatoRequestModel.Id.Equals(0) || contatoRequestModel == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Favor informar o contato a ser excluído.");

            Contato contato = Mapper.Map<ContatoRequestModel, Contato>(contatoRequestModel);
            _contatoDomainService.Deletar(contato);

            return Request.CreateResponse(HttpStatusCode.OK, "Contato excluído com sucesso.");
        }
    }
}
