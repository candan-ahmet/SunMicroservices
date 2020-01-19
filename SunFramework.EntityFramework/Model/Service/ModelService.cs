namespace SunFramework.DataAccess.Model.Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelService : DbContext
    {
        public ModelService()
            : base("name=ModelService")
        {
        }

        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<ServiceResponse> ServiceResponses { get; set; }
        public virtual DbSet<ServiceStatus> ServiceStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .Property(e => e.HostName)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.BackedServices)
                .WithOptional(e => e.BackupService)
                .HasForeignKey(e => e.BackupServiceId);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ServiceRequests)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.ServiceResponses)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceRequest>()
                .Property(e => e.RequestIP)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceRequest>()
                .Property(e => e.RequestData)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceResponse>()
                .Property(e => e.ResponseStatusCode)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceResponse>()
                .Property(e => e.ResponseData)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceStatus>()
                .Property(e => e.StatusCode)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceStatus>()
                .Property(e => e.StatusName)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceStatus>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.ServiceStatus)
                .WillCascadeOnDelete(false);
        }
    }
}
