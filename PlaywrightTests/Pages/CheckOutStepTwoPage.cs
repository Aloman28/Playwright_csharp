using Microsoft.Playwright;
namespace PlaywrightTests.Pages;

public class CheckOutStepTwoPage
{
    private readonly IPage _page;
    
    public const string Url = "https://www.saucedemo.com/checkout-step-two.html";

    public CheckOutStepTwoPage(IPage page)
    {
        _page = page;
    }

    public ILocator  FinishButton => _page.GetByRole(AriaRole.Button, new() { Name = "Finish" });
    public ILocator CheckOutPageTitle => _page.Locator(".title");

    public async Task<CheckOutCompletePage> FinishCheckOut()
    {
        await FinishButton.ClickAsync();
        return new CheckOutCompletePage(_page);       
    }
    

}