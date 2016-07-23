namespace TestJsAngDotNet.Models
{
    using App_Start;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DataContext : DbContext
    {
        public DataContext() : base(nameOrConnectionString: "PgSqlConnection")
        {
        }

        public DbSet<ListData> ListDatas { get; set; }
        public DbSet<DataInfo> DataInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}