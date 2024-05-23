using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver(); // Initialize WebDriver
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("https://example.com");

            try
            {
                Assert.AreEqual(Program.addNumbers(2, 3), 5); // Replace with your actual test logic
            }
            catch (AssertFailedException)
            {
                CaptureScreenshot("TestMethod1");
                throw; // Re-throw the exception to mark the test as failed
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            driver.Navigate().GoToUrl("https://example.com");

            try
            {
                Assert.AreEqual(Program.addNumbers(2, 3), 6); // This will intentionally fail
            }
            catch (AssertFailedException)
            {
                CaptureScreenshot("TestMethod2");
                throw; // Re-throw the exception to mark the test as failed
            }
        }

        private void CaptureScreenshot(string testName)
        {
            string screenshotDirectory = Path.Combine(TestContext.TestResultsDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotDirectory);
            string screenshotPath = Path.Combine(screenshotDirectory, $"{testName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            Console.WriteLine($"Screenshot saved: {screenshotPath}");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit(); // Clean up WebDriver
        }
    }
}

// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace TestProject1
// {
//     [TestClass]
//     public class UnitTest1
//     {
//         [TestMethod]
//         public void TestMethod1()
//         {
//             Assert.AreEqual(Program.addNumbers(2, 3), 5);
//         }
//         [TestMethod]
//         public void TestMethod2()
//         {
//             Assert.AreEqual(Program.addNumbers(2, 3), "five");
//         }

//     }
// }