﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services;
using XGame.Infrastructure.Transaction;

namespace XGame.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/jogador")]
    public class JogadorController : ControllerBase
    {
        private readonly IServiceJogador _serviceJogador;

        public JogadorController(IUnitOfWork unitOfWork, IServiceJogador serviceJogador) : base(unitOfWork)
        {
            _serviceJogador = serviceJogador;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar (AdicionarJogadorRequest request)
        {
            try
            {
                var response = _serviceJogador.AdicionarJogador(request);
                return await ResponseAsync(response, _serviceJogador);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(AlterarJogadorRequest request)
        {
            try
            {
                var response = _serviceJogador.AlterarJogador(request);
                return await ResponseAsync(response, _serviceJogador);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("Deletar")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Deletar(Guid Id)
        {
            try
            {
                var response = _serviceJogador.ExcluirJogador(Id);
                return await ResponseAsync(response, _serviceJogador);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceJogador.ListarJogador();
                return await ResponseAsync(response, _serviceJogador);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}