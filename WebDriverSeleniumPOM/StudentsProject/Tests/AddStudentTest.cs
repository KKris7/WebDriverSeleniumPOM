using NUnit.Framework;
using StudentsProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Tests
{
    public class AddStudentTest : BaseTest
    {

        [Test]
        public void Test_AddStudentContent()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            Assert.That(page.GetPageTitle, Is.EqualTo("Add Student"));
            Assert.That(page.PageUrl, Is.EqualTo("https://mvc-app-node-express.nakov.repl.co/add-student"));
            Assert.That(page.GetPageHeading, Is.EqualTo("Register New Student"));

            Assert.IsEmpty(page.InputStudentName.Text);
            Assert.IsEmpty(page.InputStudentEmail.Text);
            Assert.That(page.AddButton.Text, Is.EqualTo("Add"));
        }

        [Test]

        public void Test_AddStudent_Links()
        {
            var addStudentPage = new AddStudentPage(driver);

            addStudentPage.Open();
            addStudentPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkAddStudentPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }

        [Test]

        public void Test_AddValidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            page.InputStudentName.Clear();
            page.InputStudentEmail.Clear();

            var studentName = $"Pesho" + DateTime.Now.Ticks;
            var studentEmail = $"Peshov" + DateTime.Now.Ticks + "@abv.bg";

            page.AddStudent(studentName, studentEmail);

            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();

            Assert.That(viewStudentsPage.GetListOfStudents()
                .TakeLast(viewStudentsPage.GetListOfStudents()
                .Length).Last, Is.EqualTo($"{studentName} ({studentEmail})"));

        }

        [Test]

        public void Test_AddInvalidStudent()
        {
            var page = new AddStudentPage(driver);
            page.Open();

            page.InputStudentName.Clear();
            page.InputStudentEmail.Clear();

            var studentName = "";
            var studentEmail = "";

            page.AddStudent(studentName, studentEmail);

            page.GetErrorMessage();

            Assert.IsTrue(page.IsOpen());
            Assert.That(page.ErrorMessage.Text,
                Is.EqualTo("Cannot add student. Name and email fields are required!"));

        }
    }
}
