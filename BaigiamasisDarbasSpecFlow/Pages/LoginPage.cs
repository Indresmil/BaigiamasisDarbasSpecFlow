using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaigiamasisDarbas.BaigiamasisProjektas.Pages
{
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement navigate => driver.FindElement(By.LinkText("MANO UŽSAKYMAI"));
        private IWebElement username => driver.FindElement(By.Name("username"));
        private IWebElement password => driver.FindElement(By.Name("password"));
        private IWebElement logoutButton => driver.FindElement(By.CssSelector("#content > article > div > div > div.woocommerce-MyAccount-content > p:nth-child(2) > a"));
        private IWebElement errorMessage => driver.FindElement(By.CssSelector("#content > article > div > div > div.woocommerce-notices-wrapper > ul > li"));
        public LoginPage NavigateToLoginPage()
        {
            navigate.Click();
            return this;
        }
        public LoginPage UsernameInput(string vardas)
        {
            username.SendKeys(vardas);
            return this;
        }
        public LoginPage PasswordInput(string slaptazodis)
        {
            password.SendKeys(slaptazodis + Keys.Enter);
            return this;
        }
        public LoginPage AssertLogoutButtonVisible()
        {
            Assert.IsTrue(logoutButton.Displayed);
            return this;
        }
        public LoginPage AssertIncorrectPassword(string error)
        {
            Assert.AreEqual(error, errorMessage.Text);
            return this;
        }
        public LoginPage AssertIncorrectUsername(string error)
        {
            Assert.AreEqual(error, errorMessage.Text);
            return this;
        }
    }

}
