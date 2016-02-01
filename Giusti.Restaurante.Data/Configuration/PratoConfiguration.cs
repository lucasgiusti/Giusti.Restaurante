using System.Data.Entity.ModelConfiguration;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Data.Configuration
{
    public class PratoConfiguration : EntityTypeConfiguration<Prato>
    {
        public PratoConfiguration()
        {
            string Schema = System.Configuration.ConfigurationManager.AppSettings["Schema"];
            if (string.IsNullOrEmpty(Schema))

                this.ToTable("Prato");
            else
                this.ToTable("Prato", Schema);
            this.HasKey(i => new { i.Id });
            this.Property(i => i.Id).HasColumnName("Id");
            this.Property(i => i.CategoriaId).HasColumnName("CategoriaId");
            this.Property(i => i.Nome).HasColumnName("Nome");
            this.Property(i => i.Descricao).HasColumnName("Descricao");
            this.Property(i => i.Preco).HasColumnName("Preco");
            this.Property(i => i.Opcoes).HasColumnName("Opcoes");
            this.HasRequired(i => i.Categoria).WithMany().HasForeignKey(d => d.CategoriaId);
            this.HasMany(i => i.PedidoPratos).WithRequired().HasForeignKey(d => d.PratoId);
        }
    }
}
