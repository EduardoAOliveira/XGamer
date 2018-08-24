using System;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testando a chamada do Serviço ba Domain.
            Console.WriteLine("Iniciando....");

            var service = new ServiceJogador();
            Console.WriteLine("Criei instancia do serviço");

            AutenticarJogadorRequest AutenticarRequest = new AutenticarJogadorRequest();
            AutenticarRequest.Email = "eduiw.oliveira@gmail.com";
            AutenticarRequest.Senha = "123567";
            // Console.WriteLine("Criei instancia do meu objeto request");

            var AdicionarRequest = new AdicionarJogadorRequest()
            {
                Email = "paulo.analista@outlook.com",
                PrimeiroNome = "Eduardo",
                UltimoNome = "Almeida Oliveira",
                Senha = "123456"
            };

            var response = service.AutenticarJogador(AutenticarRequest);
            
            var response2 = service.AdicionarJogador(AdicionarRequest);

            Console.WriteLine("Serviço é valido -> "+ service.IsValid());

            // Lista as messagens de erro. (Teste)
            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });
            Console.ReadKey();
        }
    }
}
