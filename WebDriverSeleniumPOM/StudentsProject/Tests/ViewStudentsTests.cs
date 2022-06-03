using NUnit.Framework;
using StudentsProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Tests
{
    public class ViewStudentsTests : BaseTest
    {

        [Test]
        public void Test_ViewStudentsContent()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            Assert.That(page.GetPageTitle, Is.EqualTo("Students"));
            Assert.That(page.PageUrl, Is.EqualTo("https://mvc-app-node-express.nakov.repl.co/students"));
            Assert.That(page.GetPageHeading, Is.EqualTo("Registered Students"));

        }

        [Test]

        public void Test_ViewStudents_Links()
        {
            var viewStudentsPage = new ViewStudentsPage(driver);

            viewStudentsPage.Open();
            viewStudentsPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            viewStudentsPage.Open();
            viewStudentsPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            viewStudentsPage.LinkAddStudentPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());

        }

        [Test]

        public void Test_RegisteredStudents()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            var students = page.GetListOfStudents();

            foreach (var student in students)
            {
                Assert.IsTrue(student.IndexOf("(") > 0);
                Assert.IsTrue(student.LastIndexOf(")") == student.Length - 1);
            }
        }
    }
}
