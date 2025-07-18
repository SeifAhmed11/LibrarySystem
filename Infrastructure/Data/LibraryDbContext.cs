using Microsoft.EntityFrameworkCore;
using LibraryAPI.Core.Entities;

namespace LibraryAPI.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite key for BookAuthor
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            // Configure relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Floor)
                .WithMany(f => f.Employees)
                .HasForeignKey(e => e.FloorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Floor entity
            modelBuilder.Entity<Floor>()
                .Property(f => f.FloorNumber)
                .ValueGeneratedNever(); // Disable identity for FloorNumber

            modelBuilder.Entity<Floor>()
                .HasOne(f => f.Manager)
                .WithOne(e => e.ManagedFloor)
                .HasForeignKey<Employee>(e => e.ManagedFloorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.RegisteredByEmployee)
                .WithMany(e => e.RegisteredUsers)
                .HasForeignKey(u => u.RegisteredByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Shelf)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.ShelfCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shelf>()
                .HasOne(s => s.Floor)
                .WithMany(f => f.Shelves)
                .HasForeignKey(s => s.FloorNumber)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookBorrow>()
                .HasOne(bb => bb.Book)
                .WithMany(b => b.BookBorrows)
                .HasForeignKey(bb => bb.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookBorrow>()
                .HasOne(bb => bb.User)
                .WithMany(u => u.BookBorrows)
                .HasForeignKey(bb => bb.UserSSN)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookBorrow>()
                .HasOne(bb => bb.Employee)
                .WithMany(e => e.BookBorrows)
                .HasForeignKey(bb => bb.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 