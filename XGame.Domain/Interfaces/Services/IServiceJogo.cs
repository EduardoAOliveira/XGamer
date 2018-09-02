using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Interfaces.Services.Base;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogo : IServiceBase
    {
        AdicionarJogoResponse AdicionarJogo(AdicionarJogoRequest request);

        AlterarJogoResponse AlterarJogo(AlterarJogoRequest request);

        IEnumerable<JogoResponse> ListarJogo();
        ResponseBase ExcluirJogo(Guid Id);
    }
}
