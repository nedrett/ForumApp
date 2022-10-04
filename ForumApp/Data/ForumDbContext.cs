namespace ForumApp.Data
{
    using Configure;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
