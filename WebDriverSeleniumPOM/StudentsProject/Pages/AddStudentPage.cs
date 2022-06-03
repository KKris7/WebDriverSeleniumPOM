using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Pages
{
    internal class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver){ }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement InputStudentName => driver.FindElement(By.CssSelector("#name"));
        public IWebElement InputStudentEmail => driver.FindElement(By.CssSelector("#email"));
        public IWebElement AddButton => driver.FindElement(By.CssSelector("body > form > button"));
        public IWebElement ErrorMessage => driver.FindElement(By.CssSelector("body > div"));

        public string GetErrorMessage()
        {

            return ErrorMessage.Text;
        }
        public void AddStudent(string studentName , string studentEmail)
        {
            this.InputStudentName.SendKeys(studentName);
            this.InputStudentEmail.SendKeys(studentEmail);
            this.AddButton.Click();
        }


    }
}
