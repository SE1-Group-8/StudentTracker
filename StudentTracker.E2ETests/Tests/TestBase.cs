using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StudentTracker.E2ETests.Tests
{
    public class TestBase
    {
        protected IBrowser Browser = null!;
        protected IPlaywright Playwright = null!;

        [TestInitialize]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}

