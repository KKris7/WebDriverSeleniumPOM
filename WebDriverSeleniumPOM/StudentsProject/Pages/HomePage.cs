using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/";

        IWebElement StudentCountNumber => driver.FindElement(By.CssSelector("body > p > b"));

        public int GetStudentCount()
        {
            return int.Parse(StudentCountNumber.Text);
        }
    }
}
