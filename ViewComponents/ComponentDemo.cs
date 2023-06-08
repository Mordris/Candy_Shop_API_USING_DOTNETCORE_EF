using Microsoft.AspNetCore.Mvc;

namespace CandyShopAPI.ViewComponents
{
    public class ComponentDemo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
