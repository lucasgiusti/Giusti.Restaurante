using System.Data.Entity.ModelConfiguration;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Data.Configuration
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            string Schema = System.Configuration.ConfigurationManager.AppSettings["Schema"];
            if (string.IsNullOrEmpty(Schema))

                this.ToTable("Pedido");
            else
                this.ToTable("Pedido", Schema);
            this.HasKey(i => new { i.Id });
            this.Property(i => i.Id).HasColumnName("Id");
            this.Property(i => i.MesaId).HasColumnName("MesaId");
            this.Property(i => i.Situacao).HasColumnName("Situacao");
            this.Property(i => i.ValorTotal).HasColumnName("ValorTotal");
            this.HasRequired(i => i.Mesa).WithMany().HasForeignKey(d => d.MesaId);
            this.HasMany(i => i.PedidoPratos).WithRequired().HasForeignKey(d => d.PedidoId);
        }
    }
}
