using MortgageCalculatorCsharp.Models;


namespace MortgageCalculatorCsharp.Helpers
{

    public class LoanHelper
    {
        public Mortgage GetPayments(Mortgage loan)
        {
            //Calculate my Monthly Payment
            loan.Payment = CalcPayment(loan.LoanAmount, loan.InterestRate, loan.Term);

            //Create Loop from 1 to the term
            decimal balance = loan.LoanAmount;
            decimal totalInterest = 0.0m;
            decimal monthlyInterest = 0.0m;
            decimal monthlyPrincipal = 0.0m;
            decimal monthlyRate = CalcMonthlyRate(loan.InterestRate);

            //loop over each month until we reach the term of the loan
            for (int month = 1; month <= loan.Term; month++)
            {
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.Payment - monthlyInterest;
                balance -= monthlyPrincipal;
                LoanPayment loanPayment = new();
                loanPayment.Month = month;
                loanPayment.Payment = loan.Payment;
                loanPayment.MonthlyPrincipal = monthlyPrincipal;
                loanPayment.MonthlyInterest = monthlyInterest;
                loanPayment.TotalInterest = totalInterest;
                loanPayment.Balance = balance;

                //push the object into the loan model
                loan.MortgageCalculations.Add(loanPayment);
            }

            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.LoanAmount + totalInterest;

            //return the loan to the view
            return loan;
        }
        private decimal CalcPayment(decimal amount, decimal rate, int term)
        {
            decimal monthlyRate = CalcMonthlyRate(rate);
            double rateD = Convert.ToDouble(monthlyRate);
            double amountD = Convert.ToDouble(amount);
            double paymentD = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));
            return Convert.ToDecimal(paymentD);
        }
        private decimal CalcMonthlyRate(decimal rate)
        {
            return (rate / 1200);
        }
        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return (balance * monthlyRate);
        }
    }

}
