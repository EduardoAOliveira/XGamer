using System;
using System.Collections.Generic;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador :IRepositoryBase<Jogador,Guid>
    {
        ////Jogador AutenticarJogador(string email, string senha);

        // Com a criação do Repositorio Base, esses metodos foram substituidos pelo Base, não sendo mais necessario e diminuindo o codigo.
        //Jogador AdicionarJogador(Jogador jogador);
        //IEnumerable<Jogador> ListarJogador();
        //Jogador ObterJogadorId(Guid Id);
        //void AlterarJogador(Jogador jogador);
    }
}
