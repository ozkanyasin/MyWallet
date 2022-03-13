namespace MyWallet
{
    public static class UserDatabaseBuilder
    {
        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Email);
                entity.Property(e => e.Password);
                entity.Property(e => e.IsActive);
            });

        }
    }
}