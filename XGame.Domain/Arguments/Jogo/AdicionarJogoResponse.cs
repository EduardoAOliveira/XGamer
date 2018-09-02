﻿using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogo
{
    public class AdicionarJogoResponse : IRequest
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AdicionarJogoResponse(Entities.Jogo entidade)
        {
            return new AdicionarJogoResponse()
            {
                Id = entidade.Id,
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}