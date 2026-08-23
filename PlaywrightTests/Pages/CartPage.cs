using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CartPage
{
    private readonly IPage _page;
    
    public const string Url = "https://www.saucedemo.com/cart.html";

    public CartPage(IPage page)
    {
        _page = page;
    }

    public ILocator CheckoutButton => _page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });

    //plan next, add a method to remove an item from the cart, this will be useful for testing the cart functionality
    

    //Checkout
    public async Task<CheckOutStepOnePage> CheckoutAsync()
    {
        await CheckoutButton.ClickAsync();
        await _page.WaitForURLAsync(CheckOutStepOnePage.Url);
        return new CheckOutStepOnePage(_page);
    }

}
  