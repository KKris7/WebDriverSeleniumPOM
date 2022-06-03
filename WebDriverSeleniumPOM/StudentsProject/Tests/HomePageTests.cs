using NUnit.Framework;
using StudentsProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Tests
{
    public class HomePageTests : BaseTest
    {

        [Test]
        public void Test_HomePageContent()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.That(page.GetPageTitle, Is.EqualTo("MVC Example"));
            Assert.That(page.PageUrl, Is.EqualTo("https://mvc-app-node-express.nakov.repl.co/"));
            Assert.That(page.GetPageHeading, Is.EqualTo("Students Registry"));

            page.GetStudentCount();

        }

        [Test]

        public void Test_HomePage_Links()
        {
            var homePage = new HomePage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            homePage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            homePage.Open();
            homePage.LinkAddStudentPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

        }
    }
}
