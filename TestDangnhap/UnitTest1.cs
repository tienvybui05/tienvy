using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace AutoTestWithSelenium;

[TestClass]
public class TestDangnhap
{
    IWebDriver driver;
    [SetUp]
    public void SetupTest()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }
    //Dang ky nhap sai email
    [Test,Order(1)]
    public void SigninFailed_EmailWrong()
    {
        //Load Html website
        driver.Navigate().GoToUrl("http://localhost:5100/");
        Thread.Sleep(2000);

        //driver findEmplement By.Id; By.Name, By.CSSClass, By.Xpath......
        var ButtonLogin = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/a[1]/small"));
        ButtonLogin.Click();
        Thread.Sleep(2000);

        //cuon trang xuong duoi 1 doan 1000px
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0, 1000);");
        Thread.Sleep(2000);


        var LoginInput = driver.FindElement(By.Name("Input.UserName"));
        LoginInput.Clear();
        LoginInput.SendKeys("customertest");
        Thread.Sleep(2000);

        var EmailInput = driver.FindElement(By.Name("Input.Email"));
        EmailInput.Clear();
        EmailInput.SendKeys("nhap sai email");
        Thread.Sleep(2000);

        var PasswordInput = driver.FindElement(By.Name("Input.Password"));
        PasswordInput.Clear();
        PasswordInput.SendKeys("managerpass");
        Thread.Sleep(2000);

        var PasswordInputIdentify = driver.FindElement(By.Name("Input.ConfirmPassword"));
        PasswordInputIdentify.Clear();
        PasswordInputIdentify.SendKeys("managerpass");
        Thread.Sleep(2000);

        var signinbtn = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[5]/button"));
        signinbtn.Click();
        Thread.Sleep(2000);

        //Doi chieu OutPut thuc te & OutPut ky vong??
        var outputSys = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[2]/span"));
        NUnit.Framework.Assert.That(outputSys.Text, Is.EqualTo("Địa chỉ email không hợp lệ."));

    }
    //Dang ky nhap mat khau khong hop le
    [Test,Order(2)]
    public void SigninFailed_PasswordWrong()
    {
        //Load Html website
        driver.Navigate().GoToUrl("http://localhost:5100/dang-ky");
        Thread.Sleep(2000);

        //cuon trang xuong duoi 1 doan 1000px
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0, 1000);");
        Thread.Sleep(2000);

        //driver findEmplement By.Id; By.Name, By.CSSClass, By.Xpath......

        var LoginInput = driver.FindElement(By.Name("Input.UserName"));
        LoginInput.Clear();
        LoginInput.SendKeys("customertest");
        Thread.Sleep(2000);



        var EmailInput = driver.FindElement(By.Name("Input.Email"));
        EmailInput.Clear();
        EmailInput.SendKeys("customertest@gmail.com");
        Thread.Sleep(2000);

        var PasswordInput = driver.FindElement(By.Name("Input.Password"));
        PasswordInput.Clear();
        PasswordInput.SendKeys("1"); //nhap mat khau khong hop le
        Thread.Sleep(2000);

        var PasswordInputIdentify = driver.FindElement(By.Name("Input.ConfirmPassword"));
        PasswordInputIdentify.Clear();
        PasswordInputIdentify.SendKeys("1");
        Thread.Sleep(2000);

        var signinbtn = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[5]/button"));
        signinbtn.Click();
        Thread.Sleep(2000);

        //Doi chieu OutPut thuc te & OutPut ky vong??
        var outputSys = driver.FindElement(By.XPath("//*[@id=\"Input_Password-error\"]"));
        NUnit.Framework.Assert.That(outputSys.Text, Is.EqualTo("Mật khẩu phải dài ít nhất là 6 và tối đa 50 ký tự."));

    }
    //Dang ky nhap sai mat khau xac nhan
    [Test,Order(3)]
    public void SigninFailed_PasswordIdentifyWrong()
    {
        //Load Html website
        driver.Navigate().GoToUrl("http://localhost:5100/dang-ky");
        Thread.Sleep(2000);

        //cuon trang xuong duoi 1 doan 1000px
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0, 1000);");
        Thread.Sleep(2000);


        //driver findEmplement By.Id; By.Name, By.CSSClass, By.Xpath......

        var LoginInput = driver.FindElement(By.Name("Input.UserName"));
        LoginInput.Clear();
        LoginInput.SendKeys("customertest");
        Thread.Sleep(2000);

        var EmailInput = driver.FindElement(By.Name("Input.Email"));
        EmailInput.Clear();
        EmailInput.SendKeys("customertest@gmail.com");
        Thread.Sleep(2000);

        var PasswordInput = driver.FindElement(By.Name("Input.Password"));
        PasswordInput.Clear();
        PasswordInput.SendKeys("customerpass");
        Thread.Sleep(2000);

        var PasswordInputIdentify = driver.FindElement(By.Name("Input.ConfirmPassword"));
        PasswordInputIdentify.Clear();
        PasswordInputIdentify.SendKeys("nhap sai mat khau xac nhan");
        Thread.Sleep(2000);

        var signinbtn = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[5]/button"));
        signinbtn.Click();
        Thread.Sleep(2000);

        //Doi chieu OutPut thuc te & OutPut ky vong??
        var outputSys = driver.FindElement(By.XPath("//*[@id=\"Input_ConfirmPassword-error\"]"));
        NUnit.Framework.Assert.That(outputSys.Text, Is.EqualTo("Mật khẩu và mật khẩu xác nhận không khớp."));
    }
    //Dang ky thanh cong
    [Test,Order(4)]
    public void SigninSuccessfully()
    {
        //Load Html website
        driver.Navigate().GoToUrl("http://localhost:5100/dang-ky");
        Thread.Sleep(2000);

        //cuon trang xuong duoi 1 doan 1000px
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0, 1000);");
        Thread.Sleep(2000);

        //driver findEmplement By.Id; By.Name, By.CSSClass, By.Xpath......

        var LoginInput = driver.FindElement(By.Name("Input.UserName"));
        LoginInput.Clear();
        LoginInput.SendKeys("customertest");
        Thread.Sleep(2000);

        var EmailInput = driver.FindElement(By.Name("Input.Email"));
        EmailInput.Clear();
        EmailInput.SendKeys("customertest@gmail.com");
        Thread.Sleep(2000);

        var PasswordInput = driver.FindElement(By.Name("Input.Password"));
        PasswordInput.Clear();
        PasswordInput.SendKeys("customerpass");
        Thread.Sleep(2000);

        var PasswordInputIdentify = driver.FindElement(By.Name("Input.ConfirmPassword"));
        PasswordInputIdentify.Clear();
        PasswordInputIdentify.SendKeys("customerpass");
        Thread.Sleep(1000);

        var signinbtn = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[5]/button"));
        signinbtn.Click();
        Thread.Sleep(2000);

        //Doi chieu OutPut thuc te & OutPut ky vong??
        NUnit.Framework.Assert.That(driver.Title, Is.EqualTo("Trung tâm dịch vụ cá Koi"));
    }
    //Dang ky nhap ten tai khoan da ton tai
    [Test,Order(5)]
    public void SigninFaile_UsernameAlreadyExists()
    {
        //Load Html website
        driver.Navigate().GoToUrl("http://localhost:5100/dang-ky");
        Thread.Sleep(2000);

        //cuon trang xuong duoi 1 doan 1000px
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0, 1000);");
        Thread.Sleep(2000);

        //driver findEmplement By.Id; By.Name, By.CSSClass, By.Xpath......

        var LoginInput = driver.FindElement(By.Name("Input.UserName"));
        LoginInput.Clear();
        LoginInput.SendKeys("customertest");
        Thread.Sleep(2000);

        var EmailInput = driver.FindElement(By.Name("Input.Email"));
        EmailInput.Clear();
        EmailInput.SendKeys("customertest@gmail.com");
        Thread.Sleep(2000);

        var PasswordInput = driver.FindElement(By.Name("Input.Password"));
        PasswordInput.Clear();
        PasswordInput.SendKeys("customerpass");
        Thread.Sleep(2000);

        var PasswordInputIdentify = driver.FindElement(By.Name("Input.ConfirmPassword"));
        PasswordInputIdentify.Clear();
        PasswordInputIdentify.SendKeys("customerpass");
        Thread.Sleep(2000);

        var signinbtn = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[5]/button"));
        signinbtn.Click();
        Thread.Sleep(2000);

        //Doi chieu OutPut thuc te & OutPut ky vong??
        NUnit.Framework.Assert.That(driver.Title, Is.EqualTo("Trung tâm dịch vụ cá Koi"));
    }
    [Test,Order(6)]
    //Dang nhap that bai
    public void LoginFailed()
    {
        //Load Html website
        driver.Navigate().GoToUrl("http://localhost:5100/dang-nhap");
        Thread.Sleep(2000);

        //cuon trang xuong duoi 1 doan 
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0, 500);");
        Thread.Sleep(2000);

        //driver findEmplement By.Id; By.Name, By.CSSClass, By.Xpath......
        var UserNameInput = driver.FindElement(By.Name("credential.UserName"));
        UserNameInput.Clear();
        Thread.Sleep(2000);

        UserNameInput.SendKeys("nhap sai tai khoan");//Nhap username dung
        Thread.Sleep(2000);

        var PasswordInput = driver.FindElement(By.Name("credential.Password"));
        PasswordInput.Clear();
        PasswordInput.SendKeys("nhapsaimatkhau");//Nhap pass ddung
        Thread.Sleep(2000);

        var loginbtn = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[3]/input"));
        loginbtn.Click();
        Thread.Sleep(2000);

        //Doi chieu OutPut thuc te & OutPut ky vong??
        var outputSys = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[2]/span"));
        NUnit.Framework.Assert.That(outputSys.Text, Is.EqualTo("Tên người dùng hoặc mật khẩu không hợp lệ."));
    }
    //Dang nhap thanh cong
    [Test,Order(7)]
    public void LoginSuccessfully()
    {
        //Load Html website
        driver.Navigate().GoToUrl("http://localhost:5100/dang-nhap");
        Thread.Sleep(1000);

        //cuon trang xuong duoi 1 doan 
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("window.scrollBy(0, 500);");
        Thread.Sleep(2000);

        //driver findEmplement By.Id; By.Name, By.CSSClass, By.Xpath......
        var UserNameInput = driver.FindElement(By.Name("credential.UserName"));
        UserNameInput.Clear();
        Thread.Sleep(2000);

        UserNameInput.SendKeys("customer1");//Nhap username dung
        Thread.Sleep(2000);

        var PasswordInput = driver.FindElement(By.Name("credential.Password"));
        PasswordInput.Clear();
        PasswordInput.SendKeys("customerpass");//Nhap pass ddung
        Thread.Sleep(2000);

        var loginbtn = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/form/div[3]/input"));
        loginbtn.Click();
        Thread.Sleep(2000);

        //Doi chieu OutPut thuc te & OutPut ky vong??

        NUnit.Framework.Assert.That(driver.Title, Is.EqualTo("Trung tâm dịch vụ cá Koi"));
    }
    [TearDown]
    public void CloseTest()
    {
        driver.Quit();
    }
}