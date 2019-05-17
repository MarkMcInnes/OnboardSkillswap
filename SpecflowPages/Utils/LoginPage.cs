using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;

namespace SpecflowPages.Utils
{
  public class LoginPage
    {
        public static void LoginStep()
        {
            Driver.NavigateUrl();
            Thread.Sleep(1000);

            // Click on Sign in
            Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Sign In')]")).Click();

            // Enter username
            Driver.driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("mm36107@gmail.com");

            // Enter password
            Driver.driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("hMmE98vM");

            // Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[contains(.,'Login')]")).Click();

        }

    }
}
