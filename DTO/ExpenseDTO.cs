namespace MyWallet
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } //garanti kk borcu
        public decimal Amount { get; set; } //2k
        public DateTime ExpenseDate { get; set; } //bugün
        public string? ExpenseItemName { get; set; } // kk borcu
    
    }
}