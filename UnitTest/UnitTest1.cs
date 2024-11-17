using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;

namespace Test
{
    [TestClass]
    public class Unitest1
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }


        [SetUp]
        public void Login()
        {
            driver.Navigate().GoToUrl("http://localhost:5100/admin");
            Thread.Sleep(2000);

            var UserNameInput = driver.FindElement(By.Name("credential.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(2000);

            UserNameInput.SendKeys("tienvybui05");
            Thread.Sleep(2000);

            var PasswordInput = driver.FindElement(By.Name("credential.Password"));
            PasswordInput.Clear();
            PasswordInput.SendKeys("abc123");
            Thread.Sleep(2000);

            IWebElement loginButton = driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-lg.w-100"));
            loginButton.Click();

            Thread.Sleep(5000);
        }

        //Tài khoản admin : Tạo tài khoản - Người dùng đã tồn tại
        [Test]
        public void AddUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Find the button with the specified CSS selector and click it
            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/useraccount/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(2000);

            UserNameInput.SendKeys("manager1");
            Thread.Sleep(2000);

            var PasswordInput = driver.FindElement(By.Name("UserAccount.Password"));
            PasswordInput.Clear();

            PasswordInput.SendKeys("abc123");
            Thread.Sleep(2000);

            var EmailInput = driver.FindElement(By.Name("UserAccount.Email"));
            EmailInput.Clear();
            Thread.Sleep(2000);

            EmailInput.SendKeys("vybgt721tgtrtggttg2@ut.edu.vn");
            Thread.Sleep(2000);

            // Find the dropdown element by its ID
            IWebElement roleDropdown = driver.FindElement(By.Id("UserAccount_Role"));

            // Initialize a SelectElement to interact with the dropdown
            SelectElement selectRole = new SelectElement(roleDropdown);

            // Select the "Manager" option by its visible text
            selectRole.SelectByText("Manager");
            Thread.Sleep(2000);

            // Tìm và nhấn nút "Tạo mới"
            IWebElement createButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            createButton.Click();

            Thread.Sleep(5000); // Đảm bảo bảng đã được cập nhật sau khi tạo tài khoản

            //Kì vọng
            var outputError = driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and @data-valmsg-for='UserAccount.UserName']"));
            NUnit.Framework.Assert.That(outputError.Text, Is.EqualTo("Tên người dùng đã tồn tại. Vui lòng nhập lại."));
        }

        //Tài khoản admin : Tạo tài khoản - Mật khẩu không hợp lệ
        [Test]
        public void AddUser2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Find the button with the specified CSS selector and click it
            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/useraccount/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(2000);

            UserNameInput.SendKeys("manager2");
            Thread.Sleep(2000);

            var PasswordInput = driver.FindElement(By.Name("UserAccount.Password"));
            PasswordInput.Clear();

            PasswordInput.SendKeys("abc");
            Thread.Sleep(2000);

            var EmailInput = driver.FindElement(By.Name("UserAccount.Email"));
            EmailInput.Clear();
            Thread.Sleep(2000);

            EmailInput.SendKeys("vybgt721tgtrtggttg2@ut.edu.vn");
            Thread.Sleep(2000);



            Thread.Sleep(5000); // Đảm bảo bảng đã được cập nhật sau khi tạo tài khoản

            //Kì vọng
            var passwordError = driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and @data-valmsg-for='UserAccount.Password']//span[@id='UserAccount_Password-error']"));
            NUnit.Framework.Assert.That(passwordError.Text, Is.EqualTo("Mật khẩu phải dài ít nhất là 6 và tối đa 50 ký tự."));
        }

        //Tài khoản admin : Tạo tài khoản - Mật khẩu không hợp lệ
        [Test]
        public void AddUser3()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Find the button with the specified CSS selector and click it
            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/useraccount/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(2000);

            UserNameInput.SendKeys("manager2");
            Thread.Sleep(2000);

            var EmailInput = driver.FindElement(By.Name("UserAccount.Email"));
            EmailInput.Clear();
            Thread.Sleep(2000);

            EmailInput.SendKeys("vybgt721tgtrtggttg2@ut.edu.vn");
            Thread.Sleep(2000);
            // Find the dropdown element by its ID
            IWebElement roleDropdown = driver.FindElement(By.Id("UserAccount_Role"));

            // Initialize a SelectElement to interact with the dropdown
            SelectElement selectRole = new SelectElement(roleDropdown);

            // Select the "Manager" option by its visible text
            selectRole.SelectByText("Manager");
            Thread.Sleep(2000);

            // Tìm và nhấn nút "Tạo mới"
            IWebElement createButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            createButton.Click();

            Thread.Sleep(5000); // Đảm bảo bảng đã được cập nhật sau khi tạo tài khoản



            //Kì vọng
            var passwordError = driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and @data-valmsg-for='UserAccount.Password']//span[@id='UserAccount_Password-error']"));
            NUnit.Framework.Assert.That(passwordError.Text, Is.EqualTo("Vui lòng nhập mật khẩu."));
        }

        // Tài khoản admin : Tạo tài khoản - Sai định dạng email
        [Test]
        public void AddUser4()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Find the button with the specified CSS selector and click it
            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/useraccount/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(2000);

            UserNameInput.SendKeys("manager2");
            Thread.Sleep(2000);

            var PasswordInput = driver.FindElement(By.Name("UserAccount.Password"));
            PasswordInput.Clear();

            PasswordInput.SendKeys("abc123");
            Thread.Sleep(2000);

            var EmailInput = driver.FindElement(By.Name("UserAccount.Email"));
            EmailInput.Clear();
            Thread.Sleep(2000);

            EmailInput.SendKeys("staff1@koivet.com");
            Thread.Sleep(2000);

            // Find the dropdown element by its ID
            IWebElement roleDropdown = driver.FindElement(By.Id("UserAccount_Role"));

            // Initialize a SelectElement to interact with the dropdown
            SelectElement selectRole = new SelectElement(roleDropdown);

            // Select the "Manager" option by its visible text
            selectRole.SelectByText("Manager");
            Thread.Sleep(2000);

            // Tìm và nhấn nút "Tạo mới"
            IWebElement createButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            createButton.Click();

            Thread.Sleep(5000); // Đảm bảo bảng đã được cập nhật sau khi tạo tài khoản

            //Kì vọng
            var emailError = driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and @data-valmsg-for='UserAccount.Email']"));
            NUnit.Framework.Assert.That(emailError.Text, Is.EqualTo("Email đã tồn tại. Vui lòng nhập lại."));

        }

        // Tài khoản admin : Tạo tài khoản - Thành công
        [Test]
        public void AddUser5()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Find the button with the specified CSS selector and click it
            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/useraccount/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(2000);

            UserNameInput.SendKeys("manager2");
            Thread.Sleep(2000);

            var PasswordInput = driver.FindElement(By.Name("UserAccount.Password"));
            PasswordInput.Clear();

            PasswordInput.SendKeys("abc123");
            Thread.Sleep(2000);

            var EmailInput = driver.FindElement(By.Name("UserAccount.Email"));
            EmailInput.Clear();
            Thread.Sleep(2000);

            EmailInput.SendKeys("managervy2@koivet.com");
            Thread.Sleep(2000);

            // Find the dropdown element by its ID
            IWebElement roleDropdown = driver.FindElement(By.Id("UserAccount_Role"));

            // Initialize a SelectElement to interact with the dropdown
            SelectElement selectRole = new SelectElement(roleDropdown);

            // Select the "Manager" option by its visible text
            selectRole.SelectByText("Manager");
            Thread.Sleep(2000);

            // Tìm và nhấn nút "Tạo mới"
            IWebElement createButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            createButton.Click();

            Thread.Sleep(8000); // Đảm bảo bảng đã được cập nhật sau khi tạo tài khoản

            //Kì vọng
            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/useraccount"));
        }


        // Tài khoản admin : Sửa tài khoản - tên người dùng hoặc mail đã tồn tại
        [Test]
        public void EditUser1()
        {
            // Điều hướng đến trang
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Wait until the row with 'manager2' is visible (custom waiting logic)
            IWebElement row = wait.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'manager2')]]")));

            // Find the 'Edit' button in the same row and click
            IWebElement editButton = row.FindElement(By.XPath(".//a[contains(@href, 'Edit')]"));
            editButton.Click();
            Thread.Sleep(5000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(1000);

            UserNameInput.SendKeys("staff1");
            Thread.Sleep(2000);

            var MailInput = driver.FindElement(By.Name("UserAccount.Email"));
            MailInput.Clear();
            Thread.Sleep(1000);

            MailInput.SendKeys("staff1@koivet.com");
            Thread.Sleep(1000);

            // Using XPath to locate the button by its value
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Lưu']"));
            saveButton.Click();
            Thread.Sleep(5000);

            // Using XPath to find the error message element
            IWebElement errorMessage = driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and @data-valmsg-for='UserAccount.Role' and text()='Tên người dùng hoặc email đã tồn tại. Vui lòng nhập lại.']"));
        }

        // Tài khoản admin : Sửa tài khoản - mật khẩu không hợp lệ
        [Test]
        public void EditUser2()
        {
            // Điều hướng đến trang
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Wait until the row with 'manager2' is visible (custom waiting logic)
            IWebElement row = wait.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'manager2')]]")));

            // Find the 'Edit' button in the same row and click
            IWebElement editButton = row.FindElement(By.XPath(".//a[contains(@href, 'Edit')]"));
            editButton.Click();
            Thread.Sleep(5000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(1000);

            UserNameInput.SendKeys("manager23");
            Thread.Sleep(2000);

            var PassInput = driver.FindElement(By.Name("UserAccount.Password"));
            PassInput.Clear();
            Thread.Sleep(1000);

            PassInput.SendKeys("a");
            Thread.Sleep(2000);

            var MailInput = driver.FindElement(By.Name("UserAccount.Email"));
            MailInput.Clear();
            Thread.Sleep(1000);

            MailInput.SendKeys("manager23@koivet.com");
            Thread.Sleep(1000);

            // Using XPath to locate the button by its value
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Lưu']"));
            saveButton.Click();
            Thread.Sleep(5000);

            // Using XPath to find the error message element
            IWebElement errorMessage = driver.FindElement(By.XPath("//span[text()='Mật khẩu phải dài ít nhất là 6 và tối đa 50 ký tự.']"));
        }


        // Tài khoản admin : Sửa tài khoản - thành công
        [Test]
        public void EditUser3()
        {
            // Điều hướng đến trang
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Wait until the row with 'manager2' is visible (custom waiting logic)
            IWebElement row = wait.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'manager2')]]")));

            // Find the 'Edit' button in the same row and click
            IWebElement editButton = row.FindElement(By.XPath(".//a[contains(@href, 'Edit')]"));
            editButton.Click();
            Thread.Sleep(5000);

            // Nhập thông tin


            var UserNameInput = driver.FindElement(By.Name("UserAccount.UserName"));
            UserNameInput.Clear();
            Thread.Sleep(1000);

            UserNameInput.SendKeys("manager23");
            Thread.Sleep(2000);

            var PassInput = driver.FindElement(By.Name("UserAccount.Password"));
            PassInput.Clear();
            Thread.Sleep(1000);

            PassInput.SendKeys("abc1234");
            Thread.Sleep(2000);

            var MailInput = driver.FindElement(By.Name("UserAccount.Email"));
            MailInput.Clear();
            Thread.Sleep(1000);

            MailInput.SendKeys("manager23@koivet.com");
            Thread.Sleep(1000);

            // Using XPath to locate the button by its value
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Lưu']"));
            saveButton.Click();
            Thread.Sleep(5000);

            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/useraccount"));
        }

        //// Tài khoản admin : Xem chi tiết 
        [Test]
        public void Details()
        {
            // Điều hướng đến trang
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Wait until the row with 'manager2' is visible (custom waiting logic)
            IWebElement row = wait.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'manager23')]]")));

            // Find the 'Edit' button in the same row and click
            IWebElement editButton = row.FindElement(By.XPath(".//a[contains(@href, 'Details')]"));
            editButton.Click();
            Thread.Sleep(8000);

            //Kì vọng
            IWebElement customerElement = driver.FindElement(By.XPath("//dd[text()='manager23']"));
        }

        // Tài khoản admin : Xóa tài khoản
        [Test]
        public void Delete()
        {
            // Điều hướng đến trang
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement userAccountLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/useraccount']"));
            userAccountLink.Click();
            Thread.Sleep(8000);

            // Wait until the row with 'manager2' is visible (custom waiting logic)
            IWebElement row = wait.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'manager23')]]")));

            // Find the 'Edit' button in the same row and click
            IWebElement editButton = row.FindElement(By.XPath(".//a[contains(@href, 'Delete')]"));
            editButton.Click();
            Thread.Sleep(5000);

            // Using XPath to locate the submit button by its value attribute
            IWebElement deleteButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Xóa']"));
            deleteButton.Click();
            Thread.Sleep(5000);

            //Kì vọng
            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/useraccount"));
        }


        [TearDown]
        public void Close()
        {
           driver.Quit();
        }
    }
}