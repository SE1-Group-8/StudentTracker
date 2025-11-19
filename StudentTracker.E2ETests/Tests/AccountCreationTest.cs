using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StudentTracker.E2ETests.Tests
{
    [TestClass]
    public class AccountCreationTests : TestBase
    {
        [TestMethod]
        public async Task CanCreateAccount()
        {
            var page = await Browser.NewPageAsync();

            await page.GotoAsync("http://localhost:5106/createAccount");

            // Select Student
            await page.ClickAsync("input[type=radio][value=Student]");

            await page.FillAsync("input[name=FirstName]", "John");
            await page.FillAsync("input[name=LastName]", "Doe");
            await page.FillAsync("input[name=Email]", "john@etsu.edu");
            await page.FillAsync("input[name=Password]", "Pass123!");

            await page.ClickAsync("button[type=submit]");

            // Expect redirect or UI message
            await page.WaitForSelectorAsync("text=Account created");
        }
    }
}

