using Microsoft.EntityFrameworkCore;

namespace IiotDomain
{
    public class IiotContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Reading> Readings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=db;port=3306;userid=dbuser;password=dbuserpassword;database=IIOT;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Location);
            });
            modelBuilder.Entity<Reading>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.TimeStamp).IsRequired();
                entity.Property(e => e.Type);
                entity.Property(e => e.RawValue);
                entity.HasOne(d => d.Device)
                  .WithMany(p => p.Readings);
            });
        }


    }
}