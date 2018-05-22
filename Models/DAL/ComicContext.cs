using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace MvcComic.Models.DAL
{
    public class ComicContext : DbContext
    {
        public ComicContext()
            : base("ComicContext")
        {

        }
        public DbSet<ComicBookArtist> ComicBookArtists { get; set; }

        public DbSet<ComicBook> ComicBooks { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}