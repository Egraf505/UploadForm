using Microsoft.EntityFrameworkCore;
using UploadForm.Domain;

namespace UploadForm.Persistence.Context
{
    public class UploadFormContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<FileModel> FileModels { get; set; }

        public UploadFormContext()
        {

        }

        public UploadFormContext(DbContextOptions<UploadFormContext> options)
            : base(options)
        {
            
        }        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=UploadFormdb;Username=postgres;Password=EfgraF_0256");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
