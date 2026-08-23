using PlaywrightTests.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Playwright;


namespace PlaywrightTests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class CheckoutTests : PageTest
{
    private InventoryPage _inventoryPage = null!;

    [SetUp]
    public async Task Setup()
    {
        var loginPage = new LoginPage(Page);
        await loginPage.GotoAsync();
        _inventoryPage = new InventoryPage(Page);
        await loginPage.LoginAsync("standard_user", "secret_sauce");
              
    }

    [Test]
    public async Task AddItemToCart_ContinueCheckout_CheckOutComplete()
    {  
        //what can be better: specify the item to add to cart, for example, the item name, and use POM    
        await _inventoryPage.AddToCartButton.First.ClickAsync();
        await Expect(_inventoryPage.ShoppingCartBadge).ToHaveTextAsync("1");

        await _inventoryPage.ShoppingCartLink.ClickAsync();
        await Expect(Page).ToHaveURLAsync(CartPage.Url);

        //since this test is on Inventory page, create cart page object and click checkout button to go to checkout step one page. 
        var cartPage = new CartPage(Page);
        var stepOnePage = await cartPage.CheckoutAsync();
        await Expect(Page).ToHaveURLAsync(CheckOutStepOnePage.Url);
        
        var stepTwoPage = await stepOnePage.ContinueCheckOut("Debi", "Test", "G311ED");
        await Expect(Page).ToHaveURLAsync(CheckOutStepTwoPage.Url);

        var completePage = await stepTwoPage.FinishCheckOut();
        await Expect(Page).ToHaveURLAsync(CheckOutCompletePage.Url);
        await Expect(completePage.Header).ToHaveTextAsync("Thank you for your order!");
    }
    
}