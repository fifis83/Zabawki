using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Zabawki
{
    struct Card
    {
        public String number, CVV, month, year;
    }
    static class Helper
    {
        static public Card GetCardInfo()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            WebDriver driver = new ChromeDriver(options);


            driver.Navigate().GoToUrl(Dicts.sites["CardNumber"]);

            Card card = new Card
            {
                number = driver.FindElement(By.XPath(Dicts.elements["NrKarty"])).Text.Substring(14),
                CVV = driver.FindElement(By.XPath(Dicts.elements["CVV"])).Text.Substring(6),
                month = driver.FindElement(By.XPath(Dicts.elements["Month"])).Text.Substring(6, 2),
                year = driver.FindElement(By.XPath(Dicts.elements["Year"])).Text.Substring(9)
            };
            driver.Quit();

            return card;
        }

        static public void Order(Card card, string amount)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            WebDriver driver = new ChromeDriver(options);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(Dicts.sites["PurchaseToy"]);

            // wait until page is loaded
            var input = wait.Until((d) =>
            {
                return d.FindElement(By.Name("quantity"));
            });

            // select amount of toys
            var select = new SelectElement(input);
            select.SelectByValue(amount);
            // buy toys
            input = driver.FindElement(By.XPath(Dicts.elements["BuyButton"]));
            input.Click();

            // wait page is loaded
            input = wait.Until((d) =>
            {
                return d.FindElement(By.Name("card_nmuber"));
            });

            // fill in card number
            input.Clear();
            input.SendKeys(card.number);

            // fill in card exp month
            input = driver.FindElement(By.Name("month"));
            select = new SelectElement(input);
            select.SelectByText(card.month);

            // fill in card exp year
            input = driver.FindElement(By.Name("year"));
            select = new SelectElement(input);
            select.SelectByText(card.year);

            // fill in card cvv code
            input = driver.FindElement(By.Name("cvv_code"));
            input.Clear();
            input.SendKeys(card.CVV);

            // submit card for purchase
            input = driver.FindElement(By.Name("submit"));
            input.Click();
            driver.Quit();
        }

        static public void CheckCardBalance(Card card)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            WebDriver driver = new ChromeDriver(options);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(Dicts.sites["CheckCreditBalance"]);
            // wait until page is loaded
            var input = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("card_nmuber")));
            // fill in card number
            input.Clear();
            input.SendKeys(card.number);

            input = driver.FindElement(By.Name("submit"));
            input.Click();

            // Wait until balance is loaded
            var balance = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Dicts.elements["Balance"]))).Text;

            Console.WriteLine("Na koncie znajduje się: " +balance+ "$");
                
            PrintPage(driver);

            driver.Quit();
        }

        static public void PrintPage(WebDriver driver)
        {
            // Set up print options
            PrintOptions printOptions = new PrintOptions();
            // Limit PDF to 1 page   
            printOptions.AddPageRangeToPrint("1");
            // Print page to PDF
            PrintDocument printedPage = driver.Print(printOptions);
            // Save PDF to file
            printedPage.SaveAsFile("balance.pdf");
        }
    }
}
