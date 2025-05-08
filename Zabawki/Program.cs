using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Zabawki
{
    internal class Program
    {
        static void Main()
        {
            Card card = Helper.GetCardInfo();
            Helper.Order(card, "2");
            Helper.CheckCardBalance(card);

            Helper.Order(card, "5");
            Helper.CheckCardBalance(card);
        }
    }
}