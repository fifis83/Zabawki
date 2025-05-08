using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


WebDriver driver = new ChromeDriver();

// Ustawienie opóźnienia
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

//Dane
driver.Navigate().GoToUrl("https://demo.guru99.com/payment-gateway/cardnumber.php");

String number = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/h4[1]")).Text.Substring(14);
String CVV = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/h4[2]")).Text.Substring(6);
String month = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/h4[3]")).Text.Substring(6, 2);
String year = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/h4[3]")).Text.Substring(9);
//String Exp = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/h4[3]")).Text.Substring(6);


Console.WriteLine(number + CVV + month + year);

//Zamówienie

driver.Navigate().GoToUrl("https://demo.guru99.com/payment-gateway/purchasetoy.php");
//Thread.Sleep(1000);
var input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div/div[4]/select"));


var select = new SelectElement(input);
select.SelectByValue("2");


input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div/div[8]/ul/li/input"));
input.Click();

//Podanie danych do zamówienia
/// tetstststats
//Thread.Sleep(1000);
input = driver.FindElement(By.XPath("//*[@id=\"card_nmuber\"]"));
input.Clear();
input.SendKeys(number);

input = driver.FindElement(By.XPath("//*[@id=\"month\"]"));
select = new SelectElement(input);
select.SelectByText(month);

input = driver.FindElement(By.XPath("//*[@id=\"year\"]"));
select = new SelectElement(input);
select.SelectByText(year);



input = driver.FindElement(By.XPath("//*[@id=\"cvv_code\"]"));
input.Clear();
input.SendKeys(CVV);
input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div[2]/div/ul/li/input"));
input.Click();

//Odczyt
driver.Navigate().GoToUrl("https://demo.guru99.com/payment-gateway/check_credit_balance.php");
//Thread.Sleep(1000);
input = driver.FindElement(By.XPath("//*[@id=\"card_nmuber\"]"));
input.Clear();
input.SendKeys(number);

input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div/div[6]/input"));
input.Click();



Console.WriteLine("Na koncie znajduje się: " + driver.FindElement(By.XPath("//*[@id=\"three\"]/div/div/h4/span")).Text + "$");



//Zamówienie 2

driver.Navigate().GoToUrl("https://demo.guru99.com/payment-gateway/purchasetoy.php");

//Thread.Sleep(1000);
input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div/div[4]/select"));


select = new SelectElement(input);
select.SelectByValue("5");


input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div/div[8]/ul/li/input"));
input.Click();

//Podanie danych do zamówienia 2

//Thread.Sleep(1000);
input = driver.FindElement(By.XPath("//*[@id=\"card_nmuber\"]"));
input.Clear();
input.SendKeys(number);

input = driver.FindElement(By.XPath("//*[@id=\"month\"]"));
select = new SelectElement(input);
select.SelectByText(month);

input = driver.FindElement(By.XPath("//*[@id=\"year\"]"));
select = new SelectElement(input);
select.SelectByText(year);



input = driver.FindElement(By.XPath("//*[@id=\"cvv_code\"]"));
input.Clear();
input.SendKeys(CVV);
input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div[2]/div/ul/li/input"));
input.Click();

//Odczyt 2
bool loaded = false;
while (!loaded){
    try
    {
    driver.Navigate().GoToUrl("https://demo.guru99.com/payment-gateway/check_credit_balance.php");
    input = driver.FindElement(By.XPath("//*[@id=\"card_nmuber\"]"));
    }
    catch
    {
        continue;
    }
    loaded = true;
}
//Thread.Sleep(1000);
input.Clear();
input.SendKeys(number);

input = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/form/div/div[6]/input"));
input.Click();

string balance = driver.FindElement(By.XPath("//*[@id=\"three\"]/div/div/h4/span")).Text;

Console.WriteLine("Na koncie znajduje się: " + balance + "$");


PrintOptions printOptions = new PrintOptions();
printOptions.AddPageRangeToPrint("1");
PrintDocument printedPage = driver.Print(printOptions);
printedPage.SaveAsFile("balance.pdf");

// Save the document
driver.Quit();