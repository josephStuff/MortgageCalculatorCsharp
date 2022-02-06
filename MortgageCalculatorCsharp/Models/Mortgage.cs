namespace MortgageCalculatorCsharp.Models
{
    public class Mortgage
    {
        public decimal LoanAmount { get; set; }


        public decimal InterestRate { get; set; }

        public int Term { get; set; }

        public decimal Payment { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalInterest { get; set; }

        public List<LoanPayment> MortgageCalculations { get; set; } = new List<LoanPayment>();
    }
}
