﻿using System;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador entidade)
        {
            return new AlterarJogadorResponse()
            {
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Email = entidade.Email.Endereco,
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}