namespace SunFramework.DataAccess.Model.Identity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelIdentity : DbContext
    {
        public ModelIdentity()
            : base("name=ModelIdentity")
        {
        }

        public virtual DbSet<IdentityType> IdentityTypes { get; set; }
        public virtual DbSet<LoginLog> LoginLogs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserIdentity> UserIdentities { get; set; }
        public virtual DbSet<UserPassword> UserPasswords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityType>()
                .Property(e => e.TypeName)
                .IsUnicode(false);

            modelBuilder.Entity<IdentityType>()
                .HasMany(e => e.UserIdentities)
                .WithRequired(e => e.IdentityType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleCode)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.ChildRoles)
                .WithOptional(e => e.ParentRole)
                .HasForeignKey(e => e.ParentRoleId);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserPasswords)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserIdentity>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<UserPassword>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<UserPassword>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<UserPassword>()
                .HasMany(e => e.NextUserPasswords)
                .WithOptional(e => e.ChangedUserPassword)
                .HasForeignKey(e => e.ChangedUserPasswordId);
        }
    }
}
