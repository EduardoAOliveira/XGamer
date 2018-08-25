using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Enum;
using XGame.Domain.Extensions;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    /// <summary>
    /// Classe Jogador se auto valida e controla suas notificações sem utilizar exception.
    /// </summary>
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this).IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres");
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("A Senha", "6", "32")); // validação de primeiro nome. 
            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }

            AddNotifications(nome, email);
        }
        public void AlterarJogador(Nome nome, Email email)
        {
            Nome = nome;
            Email = email;

            new AddNotifications<Jogador>(this)
                .IfFalse(Status == EnumSituacaoJogador.Ativo, "Só é possivel alterar o jogadores ativos"); // validação de primeiro nome. 
 
            AddNotifications(nome, email);
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
