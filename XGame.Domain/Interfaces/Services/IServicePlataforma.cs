using XGame.Domain.Arguments.Plataforma;

namespace XGame.Domain.Services
{
    public interface IServicePlataforma
    {
        AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest request);
    }
}
