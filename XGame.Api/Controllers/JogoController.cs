using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Interfaces.Services;
using XGame.Infrastructure.Transaction;

namespace XGame.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/jogo")]
    public class JogoController : ControllerBase
    {
        private readonly IServiceJogo _serviceJogo;

        public JogoController(IUnitOfWork unitOfWork, IServiceJogo serviceJogo) : base(unitOfWork)
        {
            _serviceJogo = serviceJogo;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar (AdicionarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AdicionarJogo(request);
                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("Alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(AlterarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AlterarJogo(request);
                return await ResponseAsync(response, _serviceJogo);
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
                var response = _serviceJogo.ExcluirJogo(Id);
                return await ResponseAsync(response, _serviceJogo);
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
                var response = _serviceJogo.ListarJogo();
                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}