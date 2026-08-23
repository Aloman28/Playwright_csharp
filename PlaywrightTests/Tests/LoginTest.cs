using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright; 
using qa_hiring_xkddou.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Diagnostics;

namespace qa_hiring_xkddou.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTests : PageTest
{
    private LoginPage _loginPage = null!;

    [SetUp]
    public async Task Setup()
    {
        _loginPage = new LoginPage(Page);
        await _loginPage.GotoAsync();
    }

    [Test]
    public async Task StandardUser_LoginSuccess()
    {
        await _loginPage.LoginAsync("standard_user", "secret_sauce");

        var inventoryPage = new InventoryPage(Page);

        await Expect(Page).ToHaveURLAsync(InventoryPage.Url);
        await Expect(inventoryPage.PageTitle).ToHaveTextAsync("Products");
    }

    [Test]
    public async Task LockedOutUser_ReturnError()
    {
        await _loginPage.LoginAsync("locked_out_user", "secret_sauce");
        await Expect(_loginPage.ErrorMessage).ToBeVisibleAsync();
        await Expect(_loginPage.ErrorMessage).ToHaveTextAsync("Epic sadface: Sorry, this user has been locked out.");
    }

    [Test]
    public async Task ProblemUser_ImagesNotLoading()
    {
        await _loginPage.LoginAsync("problem_user", "secret_sauce");

        var inventoryPage = new InventoryPage(Page);
        await Expect(Page).ToHaveURLAsync(InventoryPage.Url); 
        var images = inventoryPage.InventoryItemImages;
        var count = await images.CountAsync();
        for (int i = 0; i < count; i++)
        {              
            await Expect(images.Nth(i)).ToHaveAttributeAsync("src", new Regex("sl-404"));
        }
        
    }
    [Test]
     public async Task PerformanceGlitchUser_LoginSuccess()
    {
        var stopwatch = Stopwatch.StartNew();
        await _loginPage.LoginAsync("performance_glitch_user", "secret_sauce");

        var inventoryPage = new InventoryPage(Page);
        // Increase timeout for performance glitch user flakyness since playwright default assertion is 5000ms
        await Expect(Page).ToHaveURLAsync(InventoryPage.Url, new() { Timeout = 15000 });
        await Expect(inventoryPage.PageTitle).ToHaveTextAsync("Products", new() { Timeout = 15000 });
        stopwatch.Stop();
        //Adding visibility by logging the time taken for performance glitch user login to the console
        TestContext.Out.WriteLine($"Performance Glitch User login time: {stopwatch.ElapsedMilliseconds} ms");
    }

  
}