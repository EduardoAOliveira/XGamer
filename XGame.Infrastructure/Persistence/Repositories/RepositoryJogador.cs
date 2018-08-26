using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infrastructure.Persistence.Map;
using System.Data.Entity;
using XGame.Infrastructure.Persistence.Repositories.Base;

namespace XGame.Infrastructure.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador,Guid>, IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context) : base(context)
        {
            _context = context;
        }

        //Substituindo pelo repositorio Base.

        //public Jogador AutenticarJogador(string email, string senha)
        //{
        //    throw new NotImplementedException();
        //}

        //public Jogador AdicionarJogador(Jogador jogador)
        //{
        //    _context.Jogador.Add(jogador);
        //    _context.SaveChanges();

        //    return jogador;
        //}

        //public void AlterarJogador(Jogador jogador)
        //{
        //    _context.Jogador.Add(jogador);
        //    _context.SaveChanges();
        //}

        //public IEnumerable<Jogador> ListarJogador()
        //{
        //    return _context.Jogador.ToList();
        //}

        //public Jogador ObterJogadorId(Guid Id)
        //{
        //    return _context.Jogador.Where(x => x.Id == Id);
        //}

        //Exemplo de uso do Iqueryable antes de solicitar a execução no banco de dados.
        //public int CalulaJogadores()
        //{
        //    string nome = "Eduardo";
        //    string ultimonome = "Oliveira";
        //    string sexo = string.Empty;

        //    IQueryable<Jogador> jogadores = _context.Jogador.AsNoTracking().AsQueryable();
        //    // montando a query antes de executar no banco.
        //    if (!string.IsNullOrEmpty(nome))
        //    {
        //        jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(nome));
        //    }
        //    if (!string.IsNullOrEmpty(ultimonome))
        //    {
        //        jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(ultimonome));
        //    }
        //    if (!string.IsNullOrEmpty(sexo))
        //    {
        //        jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(sexo));
        //    }

        //    return jogadores.AsParallel().ToList().Count(); // Executar em paralelo a lista.
        //}
    }
}
