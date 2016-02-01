using System;
using System.Data.Entity;
using Giusti.Restaurante.Model;
using Giusti.Restaurante.Data.Configuration;

namespace Giusti.Restaurante.Data
{
    public class EntityContext : DbContext, IDisposable
    {
        public EntityContext(string connectionName)
            : base(connectionName)
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = false;

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoPrato> PedidoPratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EntityContext>(null);
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new PratoConfiguration());
            modelBuilder.Configurations.Add(new MesaConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new PedidoPratoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
