using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Data
{
    public class MyDbcontext:DbContext
    {
        public MyDbcontext(DbContextOptions<MyDbcontext>options):base(options)
        {
            
        }
        public DbSet<Member> Member { get; set; }   
        public DbSet<BorrowTransaction> BorrowTransaction { get; set; }
        public DbSet<Category> categories {  get; set; }    
        public DbSet<Fine> Fine { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BorrowTransaction>()
                .Property(s => s.StatusstatusBorrowTransaction).HasConversion<string>();
            modelBuilder.Entity<Fine>()
                .Property(d => d.Amount).HasPrecision(24, 13);
            modelBuilder.Entity<Fine>()
                .Property(s=>s.finestatus).HasConversion<string>(); 
            modelBuilder.Entity<Member>()
                .Property(d=>d.OutstandingFees).HasPrecision(24, 13);
            modelBuilder.Entity<Reservation>()
                .Property(s => s.Status).HasConversion<string>();
            modelBuilder.Entity<Member>()
                .Property(R => R.role).HasConversion<string>();
            modelBuilder.Entity<Book>()
                .HasIndex(I => I.ISBN)
                .IsUnique();
        }
    }
}
