namespace MyWallet
{
    public static class WalletDatabaseBuilder
    {
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
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