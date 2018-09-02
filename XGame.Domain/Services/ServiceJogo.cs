using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;

namespace XGame.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repositoryJogo;

        public ServiceJogo()
        {

        }
        public ServiceJogo(IRepositoryJogo repositoryJogo)
        {
            _repositoryJogo = repositoryJogo;
        }

        public AdicionarJogoResponse AdicionarJogo(AdicionarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarJogoRequest"));
                return null;
            }
            var jogo = new Jogo(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            AddNotifications(jogo);

            jogo = _repositoryJogo.Adicionar(jogo);
            if (this.IsInvalid())
            {
                return null;
            }

            return (AdicionarJogoResponse)jogo;
        }

        public AlterarJogoResponse AlterarJogo(AlterarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Alterar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarJogoRequest"));
                return null;
            }

            Jogo jogo = _repositoryJogo.ObterPorId(request.Id);

            if (jogo == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            jogo.AlterarJogo(request);

            AddNotifications(jogo);

            jogo = _repositoryJogo.Editar(jogo);

            if (this.IsInvalid())
            {
                return null;
            }
            return (AlterarJogoResponse)jogo;
        }

        public ResponseBase ExcluirJogo(Guid Id)
        {
            Jogo jogo = _repositoryJogo.ObterPorId(Id);

            if (jogo == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }
            _repositoryJogo.Remover(jogo);

            return new ResponseBase() { };
        }

        public IEnumerable<JogoResponse> ListarJogo()
        {
            return _repositoryJogo.Listar().ToList().Select(Jogo => (JogoResponse)Jogo).ToList();
        }
    }
}
