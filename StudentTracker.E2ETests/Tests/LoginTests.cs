using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StudentTracker.E2ETests.Tests
{
    [TestClass]
    public class LoginTests : TestBase
    {
        private const string BaseUrl = "http://localhost:5106";

        [TestMethod]
        public async Task CanLogin()
        {
            var context = await Browser.NewContextAsync();
            var page = await Browser.NewPageAsync();

            await page.GotoAsync($"{BaseUrl}/login");

            await page.FillAsync("input[name=Email]", "john.doe@etsu.edu");
            await page.FillAsync("input[name=Password]", "Password123");

            await page.ClickAsync("button[type=submit]");

            var headerLocator = page.Locator("h1", new PageLocatorOptions { HasText = "Welcome" });
            await headerLocator.WaitForAsync(new LocatorWaitForOptions { Timeout = 15000 });

            var welcomeText = await headerLocator.TextContentAsync();                                                                                                     

            Assert.IsTrue(welcomeText.Contains("Welcome"), $"Welcome text on Dashboard not found. FOUND {welcomeText}");  
        }
    }
}

