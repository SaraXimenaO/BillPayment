using BillPayment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillPayment.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public virtual DbSet<Invoice> Invioce { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<StatusInvoce> StatusInvoce { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) { return; }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            modelBuilder.Entity<Invoice>().HasKey(i => i.Id);
            modelBuilder.Entity<Invoice>()
                .Property(prop => prop.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Payment>().HasKey(p => p.Id);
            modelBuilder.Entity<Payment>()
                .Property(prop => prop.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<PaymentMethod>().HasKey(pm => pm.Id);
            modelBuilder.Entity<PaymentMethod>()
                .Property(prop => prop.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<StatusInvoce>().HasKey(si => si.Id);
            modelBuilder.Entity<StatusInvoce>()
                .Property(prop => prop.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(prop => prop.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Service>().HasKey(s => s.Id);
            modelBuilder.Entity<Service>()
                .Property(prop => prop.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<UserRole>().HasKey(ur => ur.Id);
            modelBuilder.Entity<UserRole>()
                .Property(prop => prop.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);

        }

    }

}
