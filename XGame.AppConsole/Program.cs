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

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            request.Email = "eduiw.oliveira@gmail.com";
            request.Senha = "123567";
            Console.WriteLine("Criei instancia do meu objeto request");

            var response = service.AutenticarJogador(request);
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
