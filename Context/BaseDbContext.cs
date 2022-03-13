namespace MyWallet
{
    public class BaseDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Expense>? Expenses { get; set; }
        public DbSet<ExpenseItem>? ExpenseItems { get; set; }
        public DbSet<Income>? Incomes { get; set; }
        public DbSet<SourceOfIncome>? SourceOfIncomes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            optionsBuilder.UseMySql("server=localhost;database=mywalletdb;user=root;port=3306;password=toortoor", serverVersion);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            IncomeDatabaseBuilder.TableBuilder(modelBuilder);
            ExpenseDatabaseBuilder.TableBuilder(modelBuilder);

           modelBuilder.Entity<User>(entity => {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name).IsRequired();
               entity.Property(e => e.Email).IsRequired();
               entity.Property(e => e.Password).IsRequired();
               entity.Property(e => e.IsActive);

           });

            modelBuilder.Entity<Wallet>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.HasMany(e => e.Expenses);
                entity.HasMany(e => e.Incomes);
                entity.HasOne(e => e.User);
            });
        }
    }
}