using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BusinessManagement.Infra.Data
{
    public class DataContext : DbContext 
    {
        #region Entities
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Regiao> Regioes{ get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<RegiaoVendedor> RegiaoVendedores { get; set; }
        public DbSet<MicroRegiao> MicroRegioes { get; set; }

        #endregion
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedor>();
            modelBuilder.Entity<Empresa>();
            modelBuilder.Entity<Regiao>();
            modelBuilder.Entity<Atendimento>();
            modelBuilder.Entity<RegiaoVendedor>();
            modelBuilder.Entity<MicroRegiao>();
            
        }
    }
}