using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using XGame.Domain.Entities;

namespace XGame.Infrastructure.Persistence.Map
{
    public class MapPlataforma : EntityTypeConfiguration<Plataforma>
    {
        public MapPlataforma()
        {
            ToTable("Plataforma");
            // Nome vai ter tamanho 50, sendo obrigatorio. 
            Property(p => p.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
