using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }
        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

           jogador = _repositoryJogador.AdicionarJogador(jogador);

            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse AdicionarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarJogadorRequest", Message.X0_E_OBRIGATORIA.ToFormat("AlterarJogadorRequest"));
            }

            Jogador jogador = _repositoryJogador.ObterJogadorId(request.Id);

            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email);

            AddNotifications(jogador, email); // Adiciona as notificações das validações no service para retorno.

            if (IsInvalid())
            {
                return null;
            }

            _repositoryJogador.AlterarJogador(jogador);

            //Forma convencional.
            //AutenticarJogadorResponse response = new AutenticarJogadorResponse();

            //response.Email = jogador.Email.Endereco;
            //response.PrimeiroNome = jogador.Nome.PrimeiroNome;
            //response.Status = (int)jogador.Status;

            //return response;

            return (AlterarJogadorResponse)jogador; // Conversão explicita.
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", Message.X0_E_OBRIGATORIA.ToFormat("AutenticarJogadorRequest"));
            }
            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email); // Adiciona as notificações das validações no service para retorno.

            if (jogador.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);

            //Forma convencional.
            //AutenticarJogadorResponse response = new AutenticarJogadorResponse();

            //response.Email = jogador.Email.Endereco;
            //response.PrimeiroNome = jogador.Nome.PrimeiroNome;
            //response.Status = (int)jogador.Status;

            //return response;

            return (AutenticarJogadorResponse)jogador; // Conversão explicita.
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositoryJogador.ListarJogador().ToList().Select(Jogador => (JogadorResponse)Jogador).ToList(); // Conversão explicita e lista de jogadores no response.
        }
    }
}
