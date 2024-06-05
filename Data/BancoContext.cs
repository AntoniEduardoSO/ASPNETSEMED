using Microsoft.EntityFrameworkCore;
using ASPNETSEMED.Models;
using ASPNETSEMED.Converters;

namespace ASPNETSEMED.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        
        

        public DbSet<AnydeskModel> Anydesk { get; set; }


         public DbSet<ImpressoraModel> Impressora { get; set; }

        public DbSet<EscolaModel> Escola {get;set;}


         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var inetConverter = new InetValueConverter();

            

            // Configuração para o campo Ip com o conversor de valor
            modelBuilder.Entity<EscolaModel>(entity =>
            {
                entity.Property(e => e.Ip)
                    .HasConversion(inetConverter)
                    .HasColumnType("inet");
            });

            modelBuilder.Entity<ImpressoraModel>(entity =>
            {
                entity.Property(e => e.Ip)
                    .HasConversion(inetConverter)
                    .HasColumnType("inet");
            });
        }
    }
}