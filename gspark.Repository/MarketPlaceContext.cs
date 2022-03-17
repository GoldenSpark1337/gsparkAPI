using gspark.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace gspark.Repository
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class MarketPlaceContext : IdentityDbContext<User, UserRole, int,
    IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options) : base(options)
        {

//#if DEBUG
//            if (System.Diagnostics.Debugger.IsAttached == false)
//            {
//                System.Diagnostics.Debugger.Launch();
//            }
//#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(user => user.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            modelBuilder.Entity<UserRole>()
                .HasMany(user => user.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            // optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        
        public DbSet<Track> Tracks => Set<Track>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<RecordLabel> RecordLabels => Set<RecordLabel>();
        public DbSet<Kit> Kits => Set<Kit>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Vst> Vsts => Set<Vst>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Subgenre> Subgenres => Set<Subgenre>();
        public DbSet<Key> Keys => Set<Key>();
        public DbSet<File> UploadedFiles => Set<File>();
    }
}
