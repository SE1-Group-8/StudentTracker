using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StudentTracker.E2ETests.Tests
{
    [TestClass]
    public class LoginTests : TestBase
    {
        [TestMethod]
        public async Task CanLogin()
        {
            var page = await Browser.NewPageAsync();

            await page.GotoAsync("http://localhost:5106/login");

            await page.FillAsync("input[name=Email]", "johnteach@etsu.edu");
            await page.FillAsync("input[name=Password]", "Password");

            await page.ClickAsync("button[type=submit]");

            // Should land on the user dashboard
            await page.WaitForURLAsync("http://localhost:5106/");
            await page.WaitForSelectorAsync("text=Dashboard");
        }
    }
}

