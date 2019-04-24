using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleApplication1
{
    public class SeleniumTestApi
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement TreePlaceHolder { get; set; }

        public SeleniumTestApi()
        {
            driver = new ChromeDriver("WebDrivers");
        }

        public void RunTest1()
        {
            try
            {
                driver.Url = "http://www.google.pl";
                driver.Manage().Window.Maximize();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(c => c.FindElement(By.Id("searchform")));

                IWebElement searchForm = driver.FindElement(By.ClassName("RNNXgb"));
                var searchInput = searchForm.FindElement(By.TagName("input"));
                searchInput.SendKeys("Lorem ipsum");
                searchInput.SendKeys(Keys.Enter);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
