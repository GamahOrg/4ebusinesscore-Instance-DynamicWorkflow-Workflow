
namespace Infrastructure.Context
{
    public class DBContext : DbContext
    {
        public DbSet<RequestCategory> RequestCategories { get; set; }

        public DbSet<RequestInstance> RequestInstances { get; set; }
        public DbSet<RequestTemplateStep> RequestTemplateSteps { get; set; }
        public DbSet<RequestTemplate> RequestTemplates { get; set; }
        public DbSet<RequestTransaction> RequestTransactions { get; set; }
        public DbSet<RequestCategoryType> RequestCategoryType { get; set; }

        public DbSet<DefaultExceptionActionTacker> DefaultExceptionActionTacker { get; set; }
        public DbSet<ExceptionActionTacker> ExceptionActionTacker { get; set; }

        public DbSet<RequireEditFormStep> RequireEditFormStep { get; set; }

        public DbSet<RequestInstanceUser> RequestInstanceUsers { get; set; }


        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DBContext()
        {

        }

        //DbSets

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}