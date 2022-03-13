namespace MyWallet
{
    public class Income
    {
        public int Id { get; set; }
        public string? Name { get; set; } //sahabt maaş
        public decimal Amount { get; set; } //5k
        public DateTime IncomeDate { get; set; } //bugün
        public SourceOfIncome? SourceOfIncome { get; set; } //maaş
    
    }
}