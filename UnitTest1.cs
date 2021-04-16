using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AmazonItem
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Mobiles under 12000");            
            driver.FindElement(By.Id("nav-search-submit-button")).Submit();
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(@"D:\MyCode\AmazonItem\0Screenshots\"+ DateTime.Now.Millisecond+ ".png", ScreenshotImageFormat.Png);
            Assert.Pass();
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();

        }
    }
}