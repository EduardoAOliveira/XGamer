using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador()
        {

        }
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this).IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres");

        }
        public Guid Id { get; private set; }

        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; private set; }

        public override string ToString()
        {
            return this. Nome.PrimeiroNome + " " + this.Nome.UltimoNome;
        }
    }
}
