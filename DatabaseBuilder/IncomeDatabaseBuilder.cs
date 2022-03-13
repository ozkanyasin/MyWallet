namespace MyWallet
{
    public static class IncomeDatabaseBuilder
    {
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount);
                entity.Property(e => e.IncomeDate);
                entity.HasOne(e => e.SourceOfIncome);
            });

           modelBuilder.Entity<SourceOfIncome>(entity => {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name);
           });
        }
    }
}