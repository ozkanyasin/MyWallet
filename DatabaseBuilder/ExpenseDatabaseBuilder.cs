namespace MyWallet{
    public static class ExpenseDatabaseBuilder{
        public static void TableBuilder(ModelBuilder modelBuilder){
             modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount);
                entity.Property(e => e.ExpenseDate);
                entity.HasOne(e => e.ExpenseItem);
            });

           modelBuilder.Entity<ExpenseItem>(entity => {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name);
           });
        }
    }
}