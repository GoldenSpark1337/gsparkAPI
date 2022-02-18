namespace gspark.Repository
{
    using gspark.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class MarketPlaceContext : DbContext
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Track> Tracks => Set<Track>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<RecordLabel> RecordLabels => Set<RecordLabel>();
        public DbSet<Kit> Kits => Set<Kit>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Vst> Vsts => Set<Vst>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Subgenre> Subgenres => Set<Subgenre>();
        public DbSet<Key> Keys => Set<Key>();
        public DbSet<UploadedFile> UploadedFiles => Set<UploadedFile>();
    }
}
