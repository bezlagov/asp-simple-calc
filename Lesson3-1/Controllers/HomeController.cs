using Microsoft.AspNetCore.Mvc;

namespace Lesson3_1.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstDigit = "", string secondDigit = "", string operation = "")
        {
            var result = "";
            if (!string.IsNullOrEmpty(operation))
            {
                result = Calculate(firstDigit, secondDigit, operation);
            }
            return View((object)result);
        }

        private string Calculate(string firstDigit, string secondDigit, string operation)
        {
            if (operation == "*")
            {
                return CalculateMulti(firstDigit, secondDigit);
            }
            else if (operation == "/")
            {
                return CalculateDiv(firstDigit, secondDigit);
            }
            else if (operation == "+")
            {
                return CalculateSum(firstDigit, secondDigit);
            }
            else
            {
                return CalculateSubst(firstDigit, secondDigit);
            }
        }

        private string CalculateSum(string firstDigit, string secondDigit)
        {
            float digit1 = 0;
            float digit2 = 0;
            if (float.TryParse(firstDigit, out digit1) && float.TryParse(secondDigit, out digit2))
            {
                return (digit1 + digit2).ToString();
            }
            return "";
        }
        private string CalculateSubst(string firstDigit, string secondDigit)
        {
            float digit1 = 0;
            float digit2 = 0;
            if (float.TryParse(firstDigit, out digit1) && float.TryParse(secondDigit, out digit2))
            {
                return (digit1 - digit2).ToString();
            }
            return "";
        }
        private string CalculateDiv(string firstDigit, string secondDigit)
        {
            float digit1 = 0;
            float digit2 = 0;
            if (float.TryParse(firstDigit, out digit1) && float.TryParse(secondDigit, out digit2))
            {
                if (digit2 == 0)
                {
                    return "NaN";
                }
                return (digit1 / digit2).ToString();
            }
            return "";
        }
        private string CalculateMulti(string firstDigit, string secondDigit)
        {
            float digit1 = 0;
            float digit2 = 0;
            if (float.TryParse(firstDigit, out digit1) && float.TryParse(secondDigit, out digit2))
            {
                return (digit1 * digit2).ToString();
            }
            return "";
        }
    }
}
