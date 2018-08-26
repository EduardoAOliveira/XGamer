﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services;
using XGame.Infrastructure.Transaction;

namespace XGame.Api.Controllers
{
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
    }
}