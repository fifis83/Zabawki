using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawki
{
    static class Dicts
    {
        static public Dictionary<string, string> elements = new Dictionary<string, string>
        {
            { "NrKarty", "//*[@id='three']//h4[contains(text(),'Card Number')]"},
            { "CVV", "//*[@id='three']//h4[contains(text(),'CVV')]" },
            { "Month", "//*[@id='three']//h4[contains(text(),'Exp')]" },
            { "Year", "//*[@id='three']//h4[contains(text(),'Exp')]"},
            { "BuyButton", "//input[@type='submit' and @Value='Buy Now']" },
            { "Quantity","//select[@name='quantity']"},
            { "Balance", "//h4[contains(text(),\"Credit Card Balance\")]/span"}

        };
        static public Dictionary<string, string> sites = new Dictionary<string, string>
        {
            { "CardNumber", "https://demo.guru99.com/payment-gateway/cardnumber.php"},
            { "PurchaseToy","https://demo.guru99.com/payment-gateway/purchasetoy.php"},
            {"CheckCreditBalance","https://demo.guru99.com/payment-gateway/check_credit_balance.php" }

        };
    }
}