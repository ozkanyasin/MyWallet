namespace MyWallet
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseTime { get; set; }
        public ExpenseItem? ExpenseItem { get; set; }
        public Wallet? Wallet { get; set; }
    }
}