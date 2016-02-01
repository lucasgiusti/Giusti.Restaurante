using System.Data.Entity.ModelConfiguration;
using Giusti.Restaurante.Model;

namespace Giusti.Restaurante.Data.Configuration
{
    public class MesaConfiguration : EntityTypeConfiguration<Mesa>
    {
        public MesaConfiguration()
        {
            string Schema = System.Configuration.ConfigurationManager.AppSettings["Schema"];
            if (string.IsNullOrEmpty(Schema))

                this.ToTable("Mesa");
            else
                this.ToTable("Mesa", Schema);
            this.HasKey(i => new { i.Id });
            this.Property(i => i.Id).HasColumnName("Id");
            this.Property(i => i.Situacao).HasColumnName("Situacao");
            this.HasMany(i => i.Pedidos).WithRequired().HasForeignKey(d => d.MesaId);
        }
    }
}
