using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightDocsSystem.Models
{
    public class FlightDocsSystemContext:DbContext
    {
        public FlightDocsSystemContext(DbContextOptions<FlightDocsSystemContext> opt): base(opt)
        {
            
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<HistoryDocument> historyDocuments { get; set; }
        public DbSet<DocumentType> documentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
