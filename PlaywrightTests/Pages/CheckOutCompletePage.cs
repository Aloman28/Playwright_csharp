using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class CheckOutCompletePage
{
    private readonly IPage _page;
    public const string Url = "https://www.saucedemo.com/checkout-complete.html";

    public CheckOutCompletePage(IPage page)
    {
        _page = page;
    }

    public ILocator Header => _page.Locator(".complete-header");
    public ILocator Text => _page.Locator(".complete-text");
}

