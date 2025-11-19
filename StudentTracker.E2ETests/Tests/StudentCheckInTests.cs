using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StudentTracker.E2ETests.Tests
{
    [TestClass]
    public class StudentCheckInTests : TestBase
    {
        private async Task<IPage> NewContextWithLocation()
        {
            var context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                Geolocation = new Geolocation { Latitude = 41.23, Longitude = -72.55 },
                Permissions = new[] { "geolocation" }
            });

            return await context.NewPageAsync();
        }

        private async Task LoginAsync(IPage page)
        {
            await page.GotoAsync("http://localhost:5106/login");

            await page.FillAsync("input[name=Email]", "john@etsu.edu");
            await page.FillAsync("input[name=Password]", "Pass123!");

            await page.ClickAsync("button[type=submit]");

            await page.WaitForURLAsync("http://localhost:5106/");
        }

        [TestMethod]
        public async Task CanCheckIn()
        {
            var page = await NewContextWithLocation();
            await LoginAsync(page);

            // Fill notes
            await page.FillAsync("textarea[name=Notes]", "Arrived");

            await page.ClickAsync("#checkin-btn");

            await page.WaitForSelectorAsync("text=Checked In");
            await page.WaitForSelectorAsync("text=41.23");
            await page.WaitForSelectorAsync("text=-72.55");
            await page.WaitForSelectorAsync("text=Timestamp");
        }

        [TestMethod]
        public async Task CannotCheckInTwice()
        {
            var page = await NewContextWithLocation();
            await LoginAsync(page);

            // First check-in
            await page.FillAsync("textarea[name=Notes]", "First");
            await page.ClickAsync("#checkin-btn");
            await page.WaitForSelectorAsync("text=Checked In");

            // Try again
            await page.ClickAsync("#checkin-btn");
            await page.WaitForSelectorAsync("text=Error: You are already checked in");
        }

        [TestMethod]
        public async Task CanCheckOut()
        {
            var page = await NewContextWithLocation();
            await LoginAsync(page);

            // Check in
            await page.FillAsync("textarea[name=Notes]", "Morning");
            await page.ClickAsync("#checkin-btn");
            await page.WaitForSelectorAsync("text=Checked In");

            // Check out
            await page.ClickAsync("#checkout-btn");
            await page.WaitForSelectorAsync("text=Checked Out");
            await page.WaitForSelectorAsync("text=Timestamp");
        }

        [TestMethod]
        public async Task CannotCheckOutWithoutCheckIn()
        {
            var page = await NewContextWithLocation();
            await LoginAsync(page);

            await page.ClickAsync("#checkout-btn");

            await page.WaitForSelectorAsync("text=Error: No active check-in found");
        }
    }
}

