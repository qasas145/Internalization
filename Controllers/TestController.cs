using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

public class TestController : Controller {
    private readonly IStringLocalizer<TestController> _localizer;
    public TestController(IStringLocalizer<TestController> _localizer) {
        this._localizer = _localizer;
    }
    public IActionResult Index() {
        var requestFeatures = HttpContext.Features.Get<IRequestCultureFeature>();
        ViewBag.Name = _localizer["name"];
        return View();
    }
    [HttpPost]
    public IActionResult ChangeCulture(string culture, string returnUrl) {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture))
        );
        return LocalRedirect(returnUrl);
    }
}