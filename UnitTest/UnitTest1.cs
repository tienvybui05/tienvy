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

namespace TestAdmin
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

            UserNameInput.SendKeys("manager1");
            Thread.Sleep(2000);

            var PasswordInput = driver.FindElement(By.Name("credential.Password"));
            PasswordInput.Clear();
            PasswordInput.SendKeys("managerpass");
            Thread.Sleep(2000);

            IWebElement loginButton = driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-lg.w-100"));
            loginButton.Click();

            Thread.Sleep(5000);
        }

        //Tài khoản admin : Tạo tài khoản - Người dùng đã tồn tại
        [Test,Order(1)]
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
        [Test,Order(2)]
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
        [Test,Order(3)]
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
        [Test,Order(4)]
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
        [Test,Order(5)]
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
        [Test,Order(6)]
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
        [Test,Order(7)]
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
        [Test,Order(8)]
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
        [Test,Order(9)]
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
        [Test,Order(10)]
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


        [Test,Order(11)]
        public void dienthongtin()
        {
            // Khởi tạo WebDriverWait
            WebDriverWait linkWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Chờ link xuất hiện và hiển thị, sau đó tìm bằng CSS Selector
            var viewDetailsLink = linkWait.Until(drv =>
                drv.FindElement(By.CssSelector("a.btn.btn-primary.btn-sm[href='/Admin/services']"))
            );

            // Nhấn vào link "Xem chi tiết"
            viewDetailsLink.Click();
            Thread.Sleep(8000);


            // Khởi tạo WebDriverWait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Chờ link xuất hiện và hiển thị, sau đó tìm
            var addServiceLink = wait.Until(drv =>
                drv.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/services/Create']"))
            );

            // Nhấn vào link "Thêm dịch vụ mới"
            addServiceLink.Click();
            Thread.Sleep(5000);

            // Khởi tạo WebDriverWait
            WebDriverWait inputWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Chờ input xuất hiện và hiển thị, sau đó tìm bằng ID hoặc CSS Selector
            var serviceNameInput = inputWait.Until(drv =>
                drv.FindElement(By.Id("Service_ServiceName")) // Có thể thay bằng: By.CssSelector("input.form-control.bg-light[name='Service.ServiceName']")
            );

            // Xóa văn bản cũ và nhập tên mới
            serviceNameInput.Clear();
            serviceNameInput.SendKeys("Tư vấn hồ cá");
            Thread.Sleep(5000);

            // Khởi tạo WebDriverWait
            WebDriverWait inputWait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Chờ input xuất hiện và hiển thị, sau đó tìm bằng ID
            var descriptionInput = inputWait1.Until(drv =>
                drv.FindElement(By.Id("Service_Description")) // Có thể thay bằng: By.CssSelector("input.form-control.bg-light[name='Service.Description']")
            );

            // Xóa văn bản cũ và nhập mô tả mới
            descriptionInput.Clear();
            descriptionInput.SendKeys("Bác sĩ đến nhà của bạn để đánh giá và tư vấn hồ cá");

            // Khởi tạo WebDriverWait
            WebDriverWait inputWait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Chờ input xuất hiện và hiển thị, sau đó tìm bằng ID
            var priceInput = inputWait2.Until(drv =>
                drv.FindElement(By.Id("Service_Price")) // Có thể thay bằng: By.CssSelector("input.form-control.bg-light[name='Service.Price']")
            );

            // Xóa giá trị cũ và nhập giá mới
            priceInput.Clear();
            priceInput.SendKeys("599");

            // Khởi tạo WebDriverWait
            WebDriverWait buttonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var createButton = buttonWait.Until(drv =>
                drv.FindElement(By.CssSelector("input[type='submit'][value='Tạo mới'][class='btn btn-primary rounded-pill px-4 py-2 shadow-sm transition-button']"))
            );
            createButton.Click();

            Thread.Sleep(3000);

            // Khởi tạo WebDriverWait
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Tìm dòng chứa tên dịch vụ (ví dụ: "Tư vấn hồ cá") và lấy phần tử chứa dịch vụ đó
            IWebElement row = wait3.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'Tư vấn hồ cá')]]")));

            // Tìm nút "Sửa" trong cùng dòng đó và nhấn vào nút
            IWebElement editButton = row.FindElement(By.XPath(".//a[contains(@href, '/Admin/services/Edit')]"));
            editButton.Click();

            // Khởi tạo WebDriverWait
            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Chờ input xuất hiện và hiển thị, sau đó tìm bằng ID
            var priceInputt = wait4.Until(drv =>
                drv.FindElement(By.Id("Service_Price"))
            );

            // Xóa giá trị cũ và nhập giá trị mới
            priceInputt.Clear();
            priceInputt.SendKeys("00");
            Thread.Sleep(5000);

            // Khởi tạo WebDriverWait
            WebDriverWait bWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var saveButton = bWait.Until(drv =>
                drv.FindElement(By.ClassName("btn-primary"))
            );

            saveButton.Click();

            Thread.Sleep(5000);

            // Chờ link chi tiết xuất hiện và tìm bằng XPath
            var detailLinkk = wait3.Until(drv =>
                drv.FindElement(By.XPath("//a[@class='btn btn-sm btn-info mx-1' and starts-with(@href, '/Admin/services/Details?id=')]"))
            );

            // Nhấn vào link "Chi tiết"
            detailLinkk.Click();

            Thread.Sleep(5000);

            // Chờ link "Quay lại" xuất hiện và tìm bằng XPath
            var backLink = wait3.Until(drv =>
                drv.FindElement(By.XPath("//a[@class='btn btn-secondary' and starts-with(@href, '/Admin/services')]"))
            );

            // Nhấn vào link "Quay lại"
            backLink.Click();

            Thread.Sleep(5000);

            // Khởi tạo WebDriverWait
            WebDriverWait waitdel = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Tìm dòng chứa tên dịch vụ (ví dụ: "Tư vấn hồ cá") và lấy phần tử chứa dịch vụ đó
            IWebElement rowW = waitdel.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'Tư vấn hồ cá')]]")));

            // Tìm nút "Xóa" trong cùng dòng đó và nhấn vào nút
            IWebElement deleteButtonLink = rowW.FindElement(By.XPath(".//a[contains(@href, '/Admin/services/Delete')]"));
            deleteButtonLink.Click();
            Thread.Sleep(5000);

            // Tìm và nhấn nút "Xóa" trên trang xác nhận
            IWebElement confirmDeleteButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Xóa']"));
            confirmDeleteButton.Click();
            Thread.Sleep(5000);

        }

        [Test,Order(12)]
        public void ThemLichLam()
        {
            WebDriverWait waitL = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var xemChiTietLink = waitL.Until(drv =>
                drv.FindElement(By.XPath("//a[@href='/Admin/vetschedule' and @class='btn btn-primary btn-sm']"))
            );
            xemChiTietLink.Click();
            Thread.Sleep(5000);

            WebDriverWait createButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Renamed to 'createButtonWait'

            // Locate the button using XPath
            var addScheduleButton = createButtonWait.Until(drv =>
                drv.FindElement(By.XPath("//a[@href='/Admin/vetschedule/Create' and contains(@class, 'btn btn-success')]"))
            );
            addScheduleButton.Click();

            Thread.Sleep(4000);
            //// dang ky lich lam - bị lỗi ngày 
            WebDriverWait dropdownWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var veterinarianDropdown = dropdownWait.Until(drv =>
                drv.FindElement(By.Id("VetSchedule_VeterinarianId"))
            );
            SelectElement selectElement = new SelectElement(veterinarianDropdown);
            selectElement.SelectByText("veterinarian1");
            Thread.Sleep(2000);

            //
            WebDriverWait dateTimeWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Renamed to 'dateTimeWait'
            var dateTimeInput = dateTimeWait.Until(drv =>
                drv.FindElement(By.Id("VetSchedule_ScheduleDate"))
            );
            dateTimeInput.Clear();
            dateTimeInput.SendKeys("09-12-2024");
            Thread.Sleep(2000);

            var CaLamInput = driver.FindElement(By.Name("VetSchedule.TimeSlot"));
            CaLamInput.Clear();
            Thread.Sleep(2000);
            CaLamInput.SendKeys("12:30AM");
            Thread.Sleep(5000);

            //
            WebDriverWait buttonWaitL = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var createButton = buttonWaitL.Until(drv =>
                drv.FindElement(By.CssSelector("input.btn.btn-primary[type='submit'][value='Tạo mới']"))
            );


            createButton.Click();

            Thread.Sleep(5000);

            IWebElement errorMessage = driver.FindElement(By.XPath("//span[text()='Không hợp lệ.']"));



        }
        [Test, Order(13)]
        public void thongtin2() //// đăng ký lịch - đúng định dạng ngày nhưng trùng lịch 
        {
            WebDriverWait waitL = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var xemChiTietLink = waitL.Until(drv =>
                drv.FindElement(By.XPath("//a[@href='/Admin/vetschedule' and @class='btn btn-primary btn-sm']"))
            );
            xemChiTietLink.Click();
            Thread.Sleep(5000);

            WebDriverWait createButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Renamed to 'createButtonWait'

            // Locate the button using XPath
            var addScheduleButton = createButtonWait.Until(drv =>
                drv.FindElement(By.XPath("//a[@href='/Admin/vetschedule/Create' and contains(@class, 'btn btn-success')]"))
            );
            addScheduleButton.Click();

            Thread.Sleep(4000);

            //// đăng ký lịch - đúng định dạng ngày

            WebDriverWait dropdownWaitt = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var veterinarianDropdownn = dropdownWaitt.Until(drv =>
                drv.FindElement(By.Id("VetSchedule_VeterinarianId"))
            );
            SelectElement selectElementt = new SelectElement(veterinarianDropdownn);
            selectElementt.SelectByText("veterinarian1");
            Thread.Sleep(2000);

            //
            WebDriverWait dateTimeWaitt = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Renamed to 'dateTimeWait'
            var dateTimeInputt = dateTimeWaitt.Until(drv =>
                drv.FindElement(By.Id("VetSchedule_ScheduleDate"))
            );
            dateTimeInputt.Clear();
            dateTimeInputt.SendKeys("12-09-2024");
            Thread.Sleep(2000);

            var CaLamInputt = driver.FindElement(By.Name("VetSchedule.TimeSlot"));
            CaLamInputt.Clear();
            Thread.Sleep(2000);
            CaLamInputt.SendKeys("12:30AM");
            Thread.Sleep(5000);

            //
            WebDriverWait buttonWaitLl = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var createButtonn = buttonWaitLl.Until(drv =>
                drv.FindElement(By.CssSelector("input.btn.btn-primary[type='submit'][value='Tạo mới']"))
            );
            createButtonn.Click();
            Thread.Sleep(5000);
            IWebElement errorMessage = driver.FindElement(By.XPath("//span[text()='Bác sĩ đã có lịch. Vui lòng chọn ngày khác.']"));
        }

        [Test,Order(14)]
        public void thongtin3() //// đăng ký lịch - đúng định dạng ngày và không trùng lịch
        {
            WebDriverWait waitL = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var xemChiTietLink = waitL.Until(drv =>
                drv.FindElement(By.XPath("//a[@href='/Admin/vetschedule' and @class='btn btn-primary btn-sm']"))
            );
            xemChiTietLink.Click();
            Thread.Sleep(5000);

            WebDriverWait createButtonWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Renamed to 'createButtonWait'

            // Locate the button using XPath
            var addScheduleButton = createButtonWait.Until(drv =>
                drv.FindElement(By.XPath("//a[@href='/Admin/vetschedule/Create' and contains(@class, 'btn btn-success')]"))
            );
            addScheduleButton.Click();

            Thread.Sleep(4000);

            //// đăng ký lịch - đúng định dạng ngày

            WebDriverWait dropdownWaitt = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var veterinarianDropdownn = dropdownWaitt.Until(drv =>
                drv.FindElement(By.Id("VetSchedule_VeterinarianId"))
            );
            SelectElement selectElementt = new SelectElement(veterinarianDropdownn);
            selectElementt.SelectByText("veterinarian1");
            Thread.Sleep(2000);

            //
            WebDriverWait dateTimeWaitt = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Renamed to 'dateTimeWait'
            var dateTimeInputt = dateTimeWaitt.Until(drv =>
                drv.FindElement(By.Id("VetSchedule_ScheduleDate"))
            );
            dateTimeInputt.Clear();
            dateTimeInputt.SendKeys("12-21-2024");
            Thread.Sleep(2000);

            var CaLamInputt = driver.FindElement(By.Name("VetSchedule.TimeSlot"));
            CaLamInputt.Clear();
            Thread.Sleep(2000);
            CaLamInputt.SendKeys("12:30AM");
            Thread.Sleep(5000);

            //
            WebDriverWait buttonWaitLl = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var createButtonn = buttonWaitLl.Until(drv =>
                drv.FindElement(By.CssSelector("input.btn.btn-primary[type='submit'][value='Tạo mới']"))
            );
            createButtonn.Click();
            Thread.Sleep(5000);
        }

        [Test,Order(15)]
        public void editlichlam()
        {
            WebDriverWait waitL = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Tìm và nhấn vào link xem chi tiết lịch làm
            var xemChiTietLink = waitL.Until(drv =>
                drv.FindElement(By.XPath("//a[@href='/Admin/vetschedule' and @class='btn btn-primary btn-sm']"))
            );
            xemChiTietLink.Click();
            Thread.Sleep(8000);

            // Đợi để đảm bảo trang chi tiết đã tải
            Thread.Sleep(5000); // Hoặc sử dụng WebDriverWait khác để chờ phần tử cụ thể trong trang chi tiết

            // Khởi tạo WebDriverWait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Tìm phần tử <a> dựa trên class và href
            IWebElement detailLink = wait.Until(drv => drv.FindElement(By.XPath("//a[@class='btn btn-sm btn-info mx-1' and contains(@href, '/Admin/vetschedule/Details?id=')]")));

            // Nhấn vào phần tử "Chi tiết"
            detailLink.Click();

            Thread.Sleep(5000);

            // Khởi tạo WebDriverWait
            WebDriverWait wai = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Tìm phần tử <a> dựa trên class và href
            IWebElement backButton = wai.Until(drv =>
                drv.FindElement(By.XPath("//a[@class='btn btn-secondary' and @href='/Admin/vetschedule']"))
            );

            // Nhấn vào phần tử "Quay lại"
            backButton.Click();

        }

        //tạo chi phí: tạo thành công
        [Test,Order(16)]
        public void AddCost()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement CostLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/cost']"));
            CostLink.Click();
            Thread.Sleep(5000);

            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/cost/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Chọn dịch vụ từ dropdown
            var serviceIdDropdown = driver.FindElement(By.Id("Cost_ServiceId"));
            SelectElement selectService = new SelectElement(serviceIdDropdown);

            // Chọn dịch vụ theo giá trị ServiceID (Ví dụ: "Kiểm tra tại nhà" có ServiceID = 2)
            selectService.SelectByValue("2");  // Chọn "Kiểm tra tại nhà" theo giá trị value = "2"
            Thread.Sleep(2000);

            var costInput = driver.FindElement(By.Id("Cost_Cost1"));
            costInput.Clear();
            costInput.SendKeys("150.00");
            Thread.Sleep(2000);

            var additionalFeesInput = driver.FindElement(By.Id("Cost_AdditionalFees"));
            additionalFeesInput.Clear();  // Xóa giá trị trước đó
            additionalFeesInput.SendKeys("20.00");  // Nhập phí phụ mới
            Thread.Sleep(2000);

            // Định nghĩa các giá trị kỳ vọng cho chi phí mới
            string expectedCost = "150.00";  // Chi phí dịch vụ
            string expectedAdditionalFees = "20.00";  // Phí phụ

            // Tìm và nhấn nút "Tạo chi phí"
            IWebElement createButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            createButton.Click();

            Thread.Sleep(5000); // Đảm bảo bảng đã được cập nhật sau khi tạo chi phí

            // Tìm kiếm dòng trong bảng có ServiceID giống với giá trị kỳ vọng
            IWebElement newCostRow = wait.Until(d => d.FindElement(By.XPath($"//td[contains(text(), '{expectedCost}')]")));

            // Lấy các giá trị thực tế từ các cột trong dòng đã tìm được
            string actualCost = newCostRow.Text;
            string actualAdditionalFees = newCostRow.FindElement(By.XPath("./following-sibling::td[1]")).Text;

            // So sánh giá trị thực tế và giá trị kỳ vọng
            NUnit.Framework.Assert.That(actualCost, Is.EqualTo(expectedCost), $"Cost không khớp. Mong đợi: {expectedCost}, nhưng nhận được: {actualCost}");
            NUnit.Framework.Assert.That(actualAdditionalFees, Is.EqualTo(expectedAdditionalFees), $"AdditionalFees không khớp. Mong đợi: {expectedAdditionalFees}, nhưng nhận được: {actualAdditionalFees}");

        }
        //Sửa chi phí: sửa thành công
        [Test,Order(17)]
        public void EditCost()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement CostLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/cost']"));
            CostLink.Click();
            Thread.Sleep(5000);
            ;
            //chờ đến dòng 
            IWebElement newRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '150.00')] and td[contains(text(), '20.00')]]")));
            // Nhấn nút "Chỉnh sửa" (Edit) trong dòng tương ứng
            IWebElement editButton = newRow.FindElement(By.XPath(".//a[contains(@href, 'Edit')]"));
            editButton.Click();
            Thread.Sleep(5000);

            // Chỉnh sửa giá trị chi phí và phí phụ
            var costInput = driver.FindElement(By.Id("Cost_Cost1"));
            costInput.Clear();
            costInput.SendKeys("200.00");
            Thread.Sleep(2000);

            var additionalFeesInput = driver.FindElement(By.Id("Cost_AdditionalFees"));
            additionalFeesInput.Clear();
            additionalFeesInput.SendKeys("30.00");
            Thread.Sleep(2000);

            // Nhấn nút lưu thay đổi
            IWebElement saveButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            saveButton.Click();
            Thread.Sleep(5000);

            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/cost"));
        }
        [Test,Order(18)]
        public void DetailsCost()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement CostLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/cost']"));
            CostLink.Click();
            Thread.Sleep(5000);
            IWebElement newRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '200.00')] and td[contains(text(), '30.00')]]")));
            // Nhấn nút "Xem chi tiết" (Details) trong dòng tương ứng
            IWebElement DetailsButton = newRow.FindElement(By.XPath(".//a[contains(@href, 'Details')]"));
            DetailsButton.Click();
            Thread.Sleep(5000);
            // Xác minh rằng chi phí và phí phụ hiển thị đúng trong trang chi tiết
            IWebElement costDetailElement = driver.FindElement(By.XPath("//dd[text()='200.00']"));
            IWebElement additionalFeesDetailElement = driver.FindElement(By.XPath("//dd[text()='30.00']"));

            // Kỳ vọng chi phí và phí phụ phải xuất hiện trong chi tiết
            string expectedCost = "200.00";
            string expectedAdditionalFees = "30.00";

            // Lấy giá trị thực tế từ trang chi tiết
            string actualCost = costDetailElement.Text;
            string actualAdditionalFees = additionalFeesDetailElement.Text;

            // Xác minh kết quả
            NUnit.Framework.Assert.That(actualCost, Is.EqualTo(expectedCost), $"Chi phí không đúng. Mong đợi: {expectedCost}, nhưng nhận được: {actualCost}");
            NUnit.Framework.Assert.That(actualAdditionalFees, Is.EqualTo(expectedAdditionalFees), $"Phí phụ không đúng. Mong đợi: {expectedAdditionalFees}, nhưng nhận được: {actualAdditionalFees}");
        }
        [Test,Order(19)]
        public void DeleteCost()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement CostLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/cost']"));
            CostLink.Click();
            Thread.Sleep(5000);
            IWebElement newRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '200.00')] and td[contains(text(), '30.00')]]")));
            // Nhấn nút "Xóa" (Delete) trong dòng tương ứng
            IWebElement DeleteButton = newRow.FindElement(By.XPath(".//a[contains(@href, 'Delete')]"));
            DeleteButton.Click();
            Thread.Sleep(5000);

            IWebElement deleteButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Xóa']"));
            deleteButton.Click();
            Thread.Sleep(5000);

            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/cost"));
        }

        //tạo báo cáo : tạo thành công
        [Test,Order(20)]
        public void AddReport()
        {
            // Chờ 10 giây cho tới khi các phần tử xuất hiện
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ReportLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/report']"));
            ReportLink.Click();
            Thread.Sleep(8000);

            // Tìm và nhấn vào liên kết "Tạo báo cáo"
            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/report/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Điền thông tin vào các trường nhập liệu trong form tạo báo cáo
            var reportDateInput = driver.FindElement(By.Id("Report_ReportDate"));
            reportDateInput.SendKeys("11-18-2024");

            var totalCustomersInput = driver.FindElement(By.Id("Report_TotalCustomers"));
            totalCustomersInput.SendKeys("100");

            var totalServicesInput = driver.FindElement(By.Id("Report_TotalServices"));
            totalServicesInput.SendKeys("200");

            var averageRatingInput = driver.FindElement(By.Id("Report_AverageRating"));
            averageRatingInput.SendKeys("4");

            var notesInput = driver.FindElement(By.Id("Report_Notes"));
            notesInput.SendKeys("Báo cáo tháng 11");

            // Nhấn nút "Lưu" để tạo báo cáo
            IWebElement saveButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            saveButton.Click();
            Thread.Sleep(5000);  // Chờ 5 giây để đảm bảo báo cáo đã được tạo

            // Kiểm tra xem báo cáo có xuất hiện trong danh sách hay không
            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/report"));

        }
        //tạo báo cáo: số sao phải <=1 và >=5
        [Test,Order(21)]
        public void AddReport1()
        {
            // Chờ 10 giây cho tới khi các phần tử xuất hiện
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ReportLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/report']"));
            ReportLink.Click();
            Thread.Sleep(8000);

            // Tìm và nhấn vào liên kết "Tạo báo cáo"
            IWebElement createAccountButton = driver.FindElement(By.CssSelector("a.btn.btn-success[href='/Admin/report/Create']"));
            createAccountButton.Click();
            Thread.Sleep(8000);

            // Điền thông tin vào các trường nhập liệu trong form tạo báo cáo
            var reportDateInput = driver.FindElement(By.Id("Report_ReportDate"));
            reportDateInput.SendKeys("10-20-2024");

            var totalCustomersInput = driver.FindElement(By.Id("Report_TotalCustomers"));
            totalCustomersInput.SendKeys("50");

            var totalServicesInput = driver.FindElement(By.Id("Report_TotalServices"));
            totalServicesInput.SendKeys("51");

            // Ràng buộc giá trị `AverageRating`
            var averageRating = 6; // Giá trị cần kiểm tra
            NUnit.Framework.Assert.That(averageRating >= 1 && averageRating <= 5,
                Is.True,
                $"Điểm đánh giá trung bình phải nằm trong khoảng từ 1 đến 5. Giá trị hiện tại: {averageRating}");

            var averageRatingInput = driver.FindElement(By.Id("Report_AverageRating"));
            averageRatingInput.SendKeys(averageRating.ToString());

            var notesInput = driver.FindElement(By.Id("Report_Notes"));
            notesInput.SendKeys("Báo cáo tháng 10");

            // Nhấn nút "Lưu" để tạo báo cáo
            IWebElement saveButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            saveButton.Click();
            Thread.Sleep(5000);  // Chờ 5 giây để đảm bảo báo cáo đã được tạo

            // Kiểm tra xem báo cáo có xuất hiện trong danh sách hay không
            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/report"));
        }

        //chỉnh sửa báo cáo: chỉnh thành công
        [Test,Order(22)]
        public void EditReport()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Mở trang báo cáo
            IWebElement reportLink = driver.FindElement(By.CssSelector("a[href='/admin/report']"));
            reportLink.Click();
            Thread.Sleep(5000);

            // Chờ báo cáo cần chỉnh sửa
            IWebElement newRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '100')] and td[contains(text(), '4')]]")));

            IWebElement editButton = newRow.FindElement(By.XPath(".//a[contains(@href, 'Edit')]"));
            editButton.Click();
            Thread.Sleep(5000);

            // Sửa thông tin báo cáo
            var totalCustomersInput = driver.FindElement(By.Id("Report_TotalCustomers"));
            totalCustomersInput.Clear();
            totalCustomersInput.SendKeys("120");

            var totalServicesInput = driver.FindElement(By.Id("Report_TotalServices"));
            totalServicesInput.Clear();
            totalServicesInput.SendKeys("220");

            var RatingInput = driver.FindElement(By.Id("Report_AverageRating"));
            RatingInput.Clear();
            RatingInput.SendKeys("3");

            var saveButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
            saveButton.Click();
            Thread.Sleep(5000);

            // Kiểm tra báo cáo đã được sửa thành công
            IWebElement updatedReportRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '120')]]")));
            IWebElement EditReportRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '220')]]")));
            IWebElement rateRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '3')]]")));
            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/report"));
        }
        //xem chi tiết báo cáo: xem thành công
        [Test,Order(23)]
        public void DetailsReport()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Mở trang báo cáo
            IWebElement reportLink = driver.FindElement(By.CssSelector("a[href='/admin/report']"));
            reportLink.Click();
            Thread.Sleep(5000);

            // Chờ đến báo cáo cần xem chi tiết
            IWebElement newRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '120')] and td[contains(text(), '3')]]")));

            IWebElement detailsButton = newRow.FindElement(By.XPath(".//a[contains(@href, 'Details')]"));
            detailsButton.Click();
            Thread.Sleep(5000);

            // Xác minh rằng các chi tiết báo cáo hiển thị đúng trên trang chi tiết
            IWebElement totalCustomersDetailElement = driver.FindElement(By.XPath("//dd[text()='120']"));
            IWebElement totalServicesDetailElement = driver.FindElement(By.XPath("//dd[text()='220']"));

            // Kỳ vọng số khách hàng và số dịch vụ phải xuất hiện trong chi tiết
            string expectedTotalCustomers = "120"; // Tổng số khách hàng mong đợi
            string expectedTotalServices = "220";   // Tổng số dịch vụ mong đợi

            // Lấy giá trị thực tế từ trang chi tiết
            string actualTotalCustomers = totalCustomersDetailElement.Text;
            string actualTotalServices = totalServicesDetailElement.Text;

            // Xác minh kết quả
            NUnit.Framework.Assert.That(actualTotalCustomers, Is.EqualTo(expectedTotalCustomers), $"Tổng số khách hàng không đúng. Mong đợi: {expectedTotalCustomers}, nhưng nhận được: {actualTotalCustomers}");
            NUnit.Framework.Assert.That(actualTotalServices, Is.EqualTo(expectedTotalServices), $"Tổng số dịch vụ không đúng. Mong đợi: {expectedTotalServices}, nhưng nhận được: {actualTotalServices}");
        }
        // xóa báo cáo : xóa thành công
        [Test,Order(24)]
        public void DeleteReport()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Mở trang báo cáo
            IWebElement reportLink = driver.FindElement(By.CssSelector("a[href='/admin/report']"));
            reportLink.Click();
            Thread.Sleep(5000);

            // Chờ đến báo cáo cần xóa
            IWebElement newRow = wait.Until(d => d.FindElement(By.XPath("//tr[td[contains(text(), '120')] and td[contains(text(), '3')]]")));
            IWebElement deleteButton = newRow.FindElement(By.XPath(".//a[contains(@href, 'Delete')]"));
            deleteButton.Click();
            Thread.Sleep(5000);

            IWebElement confirmDeleteButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Xóa']"));
            confirmDeleteButton.Click();
            Thread.Sleep(5000);

            // Kiểm tra báo cáo đã bị xóa
            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5100/Admin/report"));
        }

        //// Tài khoản admin : Xem chi tiết đánh giá
        [Test,Order(25)]
        public void DetailsFeedback()
        {
            // Điều hướng đến trang feedback
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement FeedbackLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/feedback']"));
            FeedbackLink.Click();
            Thread.Sleep(8000);

            // Đợi cho đến khi hiển thị hàng có 'John Doe'
            IWebElement row = wait.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'John Doe')]]")));

            // Nhấp vào nút 'Chi tiết' trong cùng hàng 
            IWebElement DetailsButton = row.FindElement(By.XPath(".//a[contains(@href, 'Details')]"));
            DetailsButton.Click();
            Thread.Sleep(8000);

            // Kì vọng 
            IWebElement customerElement = driver.FindElement(By.XPath("//dd[text()='John Doe']"));
        }

        // Tài khoản admin : Xem chi tiết Lịch sử
        [Test,Order(26)]
        public void DetailsServiceHistory()
        {
            // Điều hướng đến trang servicehistory
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement serviceHistoryLink = driver.FindElement(By.CssSelector("a.dropdown-toggle.no-arrow[href='/admin/servicehistory']"));
            serviceHistoryLink.Click();
            Thread.Sleep(8000);

            // Đợi cho đến khi hiển thị hàng có 'John Doe'
            IWebElement row = wait.Until(driver => driver.FindElement(By.XPath("//tr[td[contains(text(),'John Doe')]]")));

            // Nhấp vào nút 'Chi tiết' trong cùng hàng 
            IWebElement DetailsButton = row.FindElement(By.XPath(".//a[contains(@href, 'Details')]"));
            DetailsButton.Click();
            Thread.Sleep(8000);

            //Kì Vọng
            IWebElement customerElement = driver.FindElement(By.XPath("//dd[text()='John Doe']"));
        }
        [TearDown]
        public void Close()
        {
           driver.Quit();
        }
    }
}