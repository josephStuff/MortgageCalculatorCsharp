using Microsoft.AspNetCore.Mvc;
using MortgageCalculatorCsharp.Helpers;
using MortgageCalculatorCsharp.Models;

namespace MortgageCalculatorCsharp.Controllers
{
    public class MortgageController : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculator()
        {
            Mortgage loan = new();

            loan.Payment = 0.0m;
            loan.InterestRate = 3m;
            loan.TotalCost = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.LoanAmount= 15000m;
            loan.Term = 60;
            
            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculator(Mortgage mortgage)
        {

            LoanHelper loanHelper = new LoanHelper();
            Mortgage model = loanHelper.GetPayments(mortgage);

            return View(model);
        }

    }
}
