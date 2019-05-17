using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddingDetailsToUserProfileSteps
    {
        [Given(@"a web browser is on the Profile page")]
        public void GivenAWebBrowserIsOnTheProfilePage()
        {
            // Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Profile')]/parent::*[@class='ui eight item menu']")).Click();
        }
        
        [When(@"the user clicks on the earn target edit button")]
        public void WhenTheUserClicksOnTheEarnTargetEditButton()
        {
            // Click on Earn target edit button 
            Driver.driver.FindElement(By.XPath("//*[contains(.,'Earn Target')]/ancestor::*[@class='item']/descendant::i[@class='right floated outline small write icon']")).Click();
            Thread.Sleep(500);
        }
        
        [When(@"the user selects an earnings target of (.*)")]
        public void WhenTheUserSelectsAnEarningsTargetOf(int earningsLevel)
        {
            // Click on Earn target dropdown
            Driver.driver.FindElement(By.XPath("//select[@name='availabiltyTarget']")).Click();
            
            // Select Earn target dropdown
            IWebElement elem = Driver.driver.FindElement(By.XPath("//select[@name='availabiltyTarget']"));
            SelectElement select = new SelectElement(elem);
            select.SelectByValue(earningsLevel.ToString());
        }

        [Then(@"an earnings target of ""(.*)"" should be displayed")]
        public void ThenAnEarningsTargetOfShouldBeDisplayed(string earningsTarget)
        {
            try
            {
                // Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit Earn Target");
                Thread.Sleep(1000);

                // Get value to test
                string actualTarget = Driver.driver.FindElement(By.XPath("//*[contains(.,'Earn Target')]/ancestor::*[@class='item']/descendant::span[contains(.,'$')]")).Text;

                // Test values
                if (earningsTarget == actualTarget)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited Earnings Target Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EarningsEdited");
                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test failed: Earnings Target was not updated correctly");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                Assert.Fail(e.Message);
            }
        }

        [Given(@"the Languages tab has been selected")]
        public void GivenTheLanguagesTabHasBeenSelected()
        {
            // Click on Languages tab
            Driver.driver.FindElement(By.XPath("//a[contains(.,'Languages')]")).Click();
        }

        [Given(@"the languages list has at least (.*) languages")]
        public void GivenTheLanguagesListHasAtLeastLanguages(int minLanguageCount)
        {
            // Count entries in language table
            int rows = Driver.driver.FindElements(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/tbody/tr")).Count;

            // Mark test as inconclusive if language list does not have enough entries to perform test
            if (rows < minLanguageCount)
            {
                Assert.Inconclusive("Test unable to be run due to not enough languages in the language list");
            }
        }

        [When(@"the user clicks on the edit language button in position (.*)")]
        public void WhenTheUserClicksOnTheEditLanguageButtonInPosition(int position)
        {
            // Click on edit language button at list position
            Driver.driver.FindElement(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/descendant::*[@class='outline write icon'][" + position + "]")).Click();
            Thread.Sleep(500);
        }

        [When(@"the user updates the ""(.*)"" and (.*) of the language")]
        public void WhenTheUserUpdatesTheAndOfTheLanguage(string languageName, int languageLevel)
        {
            // Update Language
            IWebElement languageInputBox = Driver.driver.FindElement(By.XPath("//*[@placeholder='Add Language']"));
            languageInputBox.Clear();
            languageInputBox.SendKeys(languageName);
            
            // Update the language level
            Driver.driver.FindElement(By.XPath("//*[@class='ui dropdown' and @name = 'level']/option[" + languageLevel + "]")).Click();

            // Click Update Button
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }

        [Then(@"that updated ""(.*)"" and ""(.*)"" should be displayed in position (.*)")]
        public void ThenThatUpdatedAndShouldBeDisplayedInPosition(string languageName, string langaugeLevel, int position)
        {
            try
            {
                // Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language Details");
                Thread.Sleep(1000);

                // Table has header row so add 1 to get corresponding data row
                int rowIndex = position + 1;

                // Get values 
                string actualLanguageName = Driver.driver.FindElement(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/descendant::tr[" + rowIndex + "]/td[1]")).Text;
                string actualLanguageLevel = Driver.driver.FindElement(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/descendant::tr[" + rowIndex + "]/td[2]")).Text;

                // Test values
                if (languageName == actualLanguageName)
                {
                    if (langaugeLevel == actualLanguageLevel)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageEdited");
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        Assert.Fail("Test failed: Language Level was not updated correctly");
                    }
                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test failed: Language Name was not updated correctly");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                Assert.Fail(e.Message);
            }
        }

        [When(@"the user clicks on the delete language button at (.*)")]
        public void WhenTheUserClicksOnTheDeleteLanguageButtonAt(int position)
        {
            // Get count of languages to ensure only 1 was deleted
            int languageCount = Driver.driver.FindElements(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/descendant::*[@class='remove icon']")).Count;
            
            // Table has header row so add 1 to get corresponding data row
            int rowIndex = position + 1;

            // Get language name of language being deleted to ensure it was deleted
            string languageName = Driver.driver.FindElement(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/descendant::tr[" + rowIndex + "]/td[1]")).Text;

            // Store data
            ScenarioContext.Current["languageCount"] = languageCount;
            ScenarioContext.Current["languageName"] = languageName;

            // Click on delete language button at list position
            Driver.driver.FindElement(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/descendant::*[@class='remove icon'][" + position + "]")).Click();
            Thread.Sleep(500);
        }

        [Then(@"that language should not be displayed on the profile")]
        public void ThenThatLanguageShouldNotBeDisplayedOnTheProfile()
        {
            try
            {
                // Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");
                Thread.Sleep(1000);

                // Get list of language names in current language list
                ReadOnlyCollection<IWebElement> languageList = Driver.driver.FindElements(By.XPath("//*[contains(th,'Language')]/ancestor::table[@class='ui fixed table']/descendant::tbody/tr"));

                // Get count of languages
                int currentLanguageCount = languageList.Count;
                int expectedLanguageCount = (int)ScenarioContext.Current["languageCount"] - 1;

                // Check to see language name is still in current language list
                string deletedLanguageName = ScenarioContext.Current["languageName"] as string;
                bool languageFound = false;

                foreach (IWebElement row in languageList)
                {
                    string languageName = row.FindElements(By.TagName("td"))[0].Text;

                    if (languageName == deletedLanguageName)
                    {
                        languageFound = true;
                    }
                }

                // Test values
                if (currentLanguageCount == expectedLanguageCount)
                {
                    if (languageFound == false)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                    }
                    else
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        Assert.Fail("Test failed: Incorrect language was deleted");
                    }
                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail("Test failed: Language was not deleted");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                Assert.Fail(e.Message);
            }
        }
    }
}
