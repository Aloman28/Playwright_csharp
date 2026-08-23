using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests;

public class Tests
{
    [Test]
    public async Task LoginPageLoads()
    {
        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false
            });

        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://playwright.dev");

        Assert.That(await page.TitleAsync(), Does.Contain("Playwright"));
    }
}