using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaigiamasisDarbas.BaigiamasisProjektas.Test
{
    class BaseTests
    {
        public IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            ChangeDriver("chrome");
            driver.Url = "https://letenos.lt/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void ChangeDriver(string driverName)
        {
            if (driverName == "chrome")
            {
                driver = new ChromeDriver(GetChromeConfigurations());
            }
            if (driverName == "firefox")
            {
                driver = new FirefoxDriver();
            }
        }
        public void TakeScreenshot()
        {
            Screenshot screenshot = driver.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}.png");
            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotFile, "Mano screenshotas");
        }
        public void PadarykScreenshotaJeiguTestasFailed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                TakeScreenshot();
            }
        }
        public ChromeOptions GetChromeConfigurations()
        {
            ChromeOptions configurations = new ChromeOptions();
            configurations.AddArguments("start-maximized", "incognito");
            return configurations;
        } 
        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

    }
}