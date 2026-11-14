using Microsoft.EntityFrameworkCore;
using Scribo.Core.Models;
using Scribo.Infrastructure.Repositories.Config;

namespace Scribo.Infrastructure.Repositories
{
    public class RepositoryContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<LectureRecord> LectureRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LectureRecordConfig());
        }
    }
}
