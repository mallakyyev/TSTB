using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSTB.BLL.Services.Menu;

namespace TSTB.Web.Components
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        private readonly IMenuService _menuServece;
        private readonly IMemoryCache _cache;

        public HeaderMenuViewComponent(IMenuService menuService, IMemoryCache cache)
        {
            _menuServece = menuService;
            _cache = cache;
        }

        public IViewComponentResult Invoke()
        {
            var childs = _menuServece.GetAllPublishMenus();

            return View(childs);
        }
    }
}
