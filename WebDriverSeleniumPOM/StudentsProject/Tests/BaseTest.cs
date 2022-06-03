using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudentsProject.Tests
{
    public class BaseTest
    {
        protected  IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
           driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}