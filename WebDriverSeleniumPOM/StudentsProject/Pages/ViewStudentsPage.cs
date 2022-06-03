using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Pages
{
    internal class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver) { }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        public IReadOnlyCollection<IWebElement> ListOfStudents => driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetListOfStudents()
        {
            return ListOfStudents.Select(student => student.Text).ToArray();
        }
    }
}
