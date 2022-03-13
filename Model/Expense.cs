namespace MyWallet
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public ExpenseItem? ExpenseItem { get; set; }
    }
}