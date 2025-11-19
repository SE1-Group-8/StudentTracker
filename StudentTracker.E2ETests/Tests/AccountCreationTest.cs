using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StudentTracker.E2ETests.Tests
{
    [TestClass]
    public class AccountCreationTests : TestBase
    {
        private const string BaseUrl = "http://localhost:5106";

        [TestMethod]
        public async Task CanCreateAccount()
        {
            var context = await Browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync($"{BaseUrl}/createAccount");

            await page.WaitForSelectorAsync("input[name=firstName]", new PageWaitForSelectorOptions { Timeout = 60000 });

            await page.FillAsync("input[name=firstName]", "John");
            await page.FillAsync("input[name=lastName]", "Doe");
            await page.FillAsync("input[name=email]", "john.doe@etsu.edu");
            await page.FillAsync("input[name=password]", "Password123");

            await page.Locator("input[type=radio][value='\"Teacher\"']").CheckAsync();

            await page.ClickAsync("button:text('Submit')");

            await page.Locator("text=Created! Redirecting").WaitForAsync();

            await page.WaitForURLAsync("**/");
        }
    }
}

