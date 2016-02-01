using System.Data.Entity.ModelConfiguration;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Data.Configuration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            string Schema = System.Configuration.ConfigurationManager.AppSettings["Schema"];
            if (string.IsNullOrEmpty(Schema))

                this.ToTable("Categoria");
            else
                this.ToTable("Categoria", Schema);
            this.HasKey(i => new { i.Id });
            this.Property(i => i.Id).HasColumnName("Id");
            this.Property(i => i.Nome).HasColumnName("Nome");
            this.HasMany(i => i.Pratos).WithRequired().HasForeignKey(d => d.CategoriaId);
        }
    }
}
