using System.Data.Entity.ModelConfiguration;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Data.Configuration
{
    public class PedidoPratoConfiguration : EntityTypeConfiguration<PedidoPrato>
    {
        public PedidoPratoConfiguration()
        {
            string Schema = System.Configuration.ConfigurationManager.AppSettings["Schema"];
            if (string.IsNullOrEmpty(Schema))

                this.ToTable("PedidoPrato");
            else
                this.ToTable("PedidoPrato", Schema);
            this.HasKey(i => new { i.Id });
            this.Property(i => i.Id).HasColumnName("Id");
            this.Property(i => i.PedidoId).HasColumnName("PedidoId");
            this.Property(i => i.PratoId).HasColumnName("PratoId");
            this.Property(i => i.Opcoes).HasColumnName("Opcoes");
            this.Property(i => i.Situacao).HasColumnName("Situacao");
            this.HasRequired(i => i.Pedido).WithMany().HasForeignKey(d => d.PedidoId);
            this.HasRequired(i => i.Prato).WithMany().HasForeignKey(d => d.PratoId);
        }
    }
}
