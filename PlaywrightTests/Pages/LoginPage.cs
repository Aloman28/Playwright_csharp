using Microsoft.Playwright;

namespace qa_hiring_xkddou.Pages;

public class LoginPage
{
    private readonly IPage _page;
    private const string Url = "https://www.saucedemo.com/";

    public LoginPage(IPage page)
    {
        _page = page;
    }

    private ILocator UsernameInput => _page.GetByPlaceholder("username");
    private ILocator PasswordInput => _page.GetByPlaceholder("password");
    private ILocator LoginButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
    public ILocator ErrorMessage => _page.Locator("[data-test='error']");
    public async Task GotoAsync() => await _page.GotoAsync(Url);

    //Click Login button after entering username and password
    public async Task LoginAsync(string username, string password)
    {
        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);
        await LoginButton.ClickAsync();
        
    }
}
