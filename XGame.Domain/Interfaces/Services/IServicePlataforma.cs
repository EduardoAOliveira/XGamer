using XGame.Domain.Arguments.Plataforma;
using XGame.Domain.Interfaces.Services.Base;

namespace XGame.Domain.Services
{
    public interface IServicePlataforma : IServiceBase
    {
        AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest request);
    }
}
