using BaigiamasisDarbas.BaigiamasisProjektas.Pages;
using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace BaigiamasisDarbasSpecFlow.Features
{
    [Binding]
    public class LoginFeatureSteps : BaseDriver

    {
        private LoginPage loginPage;
        private IWebDriver driver;

        public void Beforetest()
        {
            loginPage = new LoginPage(driver);
        }

        [Given(@"navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            loginPage.NavigateToLoginPage();
        }

        [Given(@"input correct login name")]
        public void GivenInputCorrectLoginName()
        {
            loginPage.UsernameInput("indre.smilgaityte@gmail.com");
        }
        
        [Given(@"input correct password")]
        public void GivenInputCorrectPassword()
        {
            loginPage.PasswordInput("slaptazodis123");
        }
        
        [Then(@"the Logout button should be visible")]
        public void ThenTheLogOutButtonShouldBeVisible()
        {
            loginPage.AssertLogoutButtonVisible();
        }
    }

}
