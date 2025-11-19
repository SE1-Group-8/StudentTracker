using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentTracker.E2ETests.Tests
{
    [TestClass]
    public class StudentCheckInTests
    {
        private IBrowser? browser;
        private IPage? page;
        private IBrowserContext? context;

        [TestInitialize]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            // Grant geolocation permission
            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                Permissions = new[] { "geolocation" },
                Geolocation = new Geolocation { Latitude = 51.506F, Longitude = -0.127F },
                Locale = "en-US"
            });

            page = await context.NewPageAsync();
        }

        [TestMethod]
        public async Task TestStudentCheckInFlow()
        {
            // Login first
            await page.GotoAsync("http://localhost:5106/login");
            await page.FillAsync("input[name='Email']", "bobbyhill@etsu.edu");
            await page.FillAsync("input[name='Password']", "Password");
            await page.ClickAsync("button[type='Submit']");

            // Verify redirected to dashboard
            await page.WaitForSelectorAsync("h1:has-text('Welcome')");

            // Enter check-in notes
            await page.FillAsync("textarea[placeholder='Enter notes before checking out...']", "Test notes");

            // Click Check In
            await page.ClickAsync("btn:has-text('Check In')");

            // Wait for status update
            var status = await page.TextContentAsync("p:has-text('Status: Checked In')");
            Assert.IsNotNull(status);

            // Check latitude/longitude displayed
            var lat = await page.TextContentAsync("p:has-text('Latitude')");
            Assert.IsTrue(lat.Contains("51.506"));

            // Try to check in again -> error
            await page.ClickAsync("btn:has-text('Check In')");
            var error = await page.TextContentAsync("p.text-danger");
            Assert.AreEqual("Error: You are already checked in.", error.Trim());

            // Check Out
            await page.ClickAsync("btn:has-text('Check Out')");
            var newStatus = await page.TextContentAsync("p:has-text('Status: Checked Out')");
            Assert.IsNotNull(newStatus);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            if (page != null) await page.CloseAsync();
            if (context != null) await context.CloseAsync();
            if (browser != null) await browser.CloseAsync();
        }
    }
}

