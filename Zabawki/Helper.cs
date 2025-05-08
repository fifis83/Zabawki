using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Zabawki
{
    static class Helper
    {
        Dictionary<string, string> _elements = new Dictionary<string, string>
        {
            { "NrKarty", "//*[@id='three']//h4[contains(text(),'Card Number')]"},
            { "CVV", "//*[@id='three']//h4[contains(text(),'CVV')]" },
            { "Month", "//*[@id='three']//h4[contains(text(),'Exp')]".Substring(6,2) },
            { "Year", "//*[@id='three']//h4[contains(text(),'Exp')]".Substring(9) },
            { "BuyButton", "//input[@type='submit' and @Value='Buy Now']" },
            { "Quantity","//select[@name='quantity']"},
            { "PayButton","//input[@Class='button special']"}
           
        };
        Dictionary<string, string> _sites = new Dictionary<string, string>
        {
            { "CardNumber", "https://demo.guru99.com/payment-gateway/cardnumber.php"},
            { "PurchaseToy","https://demo.guru99.com/payment-gateway/purchasetoy.php"},
            {"CheckCreditBalance","https://demo.guru99.com/payment-gateway/check_credit_balance.php" }
           
        };
    }
}
