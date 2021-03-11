using Microsoft.EntityFrameworkCore;
using RemoteTestingApp.Core.Entities;


namespace RemoteTestingApp.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Register> Registers { get; set; }
        public DbSet<PersonalDetails> UserPersonalDetails { get; set; }
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public DbSet<UploadedDocument> UploadedDocuments { get; set; }
        public DbSet<ReviewCompanyDocument> ReviewCompanyDocuments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=LikeButtonApp.db");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
