using Microsoft.EntityFrameworkCore;
using vardar.Models;

namespace vardar.Data
{
    public class ApplicationDbCentext : DbContext //dbcontext entityframworkten gelir verileri yönetmek için kullanırız
    {
        public ApplicationDbCentext(DbContextOptions<ApplicationDbCentext> options) : base(options)//yapıcı metot tanımlıyoruz
        {//yapılan değişikler dbcontexte gönderilir
            
        }
        public DbSet<Category> Categories { get; set; }//databasede yaracağımız table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Aksiyon",DisplayOrder=1},
                new Category { Id = 2, Name = "Bilim Kurgu", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Tarih", DisplayOrder = 3 }

                );
        }
    }
}
