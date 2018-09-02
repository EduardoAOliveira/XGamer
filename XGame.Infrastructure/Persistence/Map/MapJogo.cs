using System.Data.Entity.ModelConfiguration;
using XGame.Domain.Entities;

namespace XGame.Infrastructure.Persistence.Map
{
    public class MapJogo : EntityTypeConfiguration<Jogo>
    {
        public MapJogo()
        {
            ToTable("Jogo");
            Property(p => p.Nome).HasMaxLength(100).IsRequired();
            Property(p => p.Descricao).HasMaxLength(255).IsRequired();
            Property(p => p.Produtora).HasMaxLength(50).IsRequired();
            Property(p => p.Distribuidora).HasMaxLength(100);
            Property(p => p.Genero).HasMaxLength(30).IsRequired();
            Property(p => p.Site).HasMaxLength(200);
        }
    }
}
