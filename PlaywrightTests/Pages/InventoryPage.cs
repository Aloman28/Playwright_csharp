using Microsoft.Playwright;

namespace PlaywrightTests.Pages;

public class InventoryPage
{
    private readonly IPage _page;
    // Inventory page URL after successful login used for validation in logintests
    public const string Url = "https://www.saucedemo.com/inventory.html";

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    // After Login Investory page appear and it has a title "Products"
    public ILocator PageTitle => _page.Locator(".title");
    //After Login with Problematic User with Images not loading
    public ILocator InventoryItemImages => _page.Locator("img.inventory_item_img");
    public ILocator ShoppingCartBadge => _page.Locator(".shopping_cart_badge");
    public ILocator AddToCartButton => _page.Locator("button.btn_inventory");
    public ILocator ShoppingCartLink => _page.Locator(".shopping_cart_link");


}
