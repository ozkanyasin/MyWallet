namespace MyWallet
{
    public class IncomeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } //sahabt maaş
        public decimal Amount { get; set; } //5k
        public DateTime IncomeDate { get; set; } //bugün
        public string? SourceOfIncomeName { get; set; }
    
    }
}