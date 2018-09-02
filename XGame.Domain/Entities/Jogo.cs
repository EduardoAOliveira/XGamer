using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Entities.Base;
using XGame.Domain.Resources;

namespace XGame.Domain.Entities
{
    public class Jogo: EntityBase
    {
        public Jogo()
        {

        }
        public Jogo(string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;
            ValidarEntidade();
        }
        private void ValidarEntidade()
        {
            new AddNotifications<Jogo>(this)
                .IfNullOrInvalidLength(x => x.Nome, 1, 100, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Nome", "1", "100"))
                .IfNullOrInvalidLength(x => x.Descricao, 1, 255, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descricao", "1", "255"))
                .IfNullOrInvalidLength(x => x.Produtora, 1, 50, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Produtora", "1", "50"))
                .IfNullOrInvalidLength(x => x.Distribuidora, 1, 100, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descricao", "1", "100"))
                .IfNullOrInvalidLength(x => x.Genero, 1, 30, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Genero", "1", "30"));
        }
        public void AlterarJogo(AlterarJogoRequest request)
        {
            Nome = request.Nome;
            Descricao = request.Descricao;
            Produtora = request.Produtora;
            Distribuidora = request.Distribuidora;
            Genero = request.Genero;
            Site = request.Site;
            ValidarEntidade();
        }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Produtora { get; private set; }
        public string Distribuidora { get; private set; }
        public string Genero { get; private set; }
        public string Site { get; private set; }
    }
}
