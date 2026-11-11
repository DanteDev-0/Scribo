using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Scribo.Api.Models;
using Scribo.Api.Repositories.Config;

namespace Scribo.Api.Repositories
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
