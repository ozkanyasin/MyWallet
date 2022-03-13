namespace MyWallet
{
    public class Wallet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public User? User { get; set; }
        public virtual IEnumerable<Income>? Incomes { get; set; } //list olmalı
        public virtual IEnumerable<Expense>? Expenses { get; set; }
      
    }
}