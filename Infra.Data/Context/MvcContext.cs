using Infra.Data.Mappings;
using Infra.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Infra.Data.Context
{
    public class MvcContext : DbContext
    {
        public MvcContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Pluralizing
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Non delete cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            //General Custom Context Properties
            modelBuilder.Properties()
                    .Where(p => p.Name == p.ReflectedType.Name + "Id")
                    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // Configure

            modelBuilder.Configurations.Add<Cliente>(new ClienteMap());

            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Cliente> Clientes { get; set; }


    }
}
