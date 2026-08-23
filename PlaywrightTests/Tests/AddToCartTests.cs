using PlaywrightTests.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Playwright;


namespace PlaywrightTests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class AddToCartTests : PageTest
{
    private InventoryPage _inventoryPage = null!;

    [SetUp]
    public async Task Setup()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.GotoAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");
        _inventoryPage = new InventoryPage(Page);
    }

    [Test]
    public async Task AddItemToCart_ShowsCorrectQuantity()
    {      
        await _inventoryPage.AddToCartButton.First.ClickAsync();
        await Expect(_inventoryPage.ShoppingCartBadge).ToHaveTextAsync("1"); 
    }

    //to test multiple items added to cart, we can add more items and check the quantity
    //to test removing items from cart, we can click on the remove button and check the quantity
}