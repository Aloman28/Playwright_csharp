using Microsoft.Playwright;
namespace PlaywrightTests.Pages;

public class CheckOutStepOnePage
{
    private readonly IPage _page;
    
    public const string Url = "https://www.saucedemo.com/checkout-step-one.html";

    public CheckOutStepOnePage(IPage page)
    {
        _page = page;
    }

    public ILocator  FirstNameField=> _page.GetByPlaceholder("First Name");
    public ILocator  LastNameField => _page.GetByPlaceholder("Last Name");
    public ILocator  PostalCodeField => _page.GetByPlaceholder("Zip/Postal Code");
    public ILocator  ContinueButton => _page.GetByRole(AriaRole.Button, new() { Name = "Continue" });

        //Checkout
        public async Task<CheckOutStepTwoPage> ContinueCheckOut(string firstName, string lastName, string postalCode)
    {
        await FirstNameField.FillAsync(firstName);
        await LastNameField.FillAsync(lastName);
        await PostalCodeField.FillAsync(postalCode);
        await ContinueButton.ClickAsync();
        await _page.WaitForURLAsync(CheckOutStepTwoPage.Url);
        return new CheckOutStepTwoPage(_page);       
    }

}
  