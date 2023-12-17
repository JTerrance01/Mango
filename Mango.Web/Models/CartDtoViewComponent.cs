using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Mango.Web.Models
{
	public class CartDtoViewComponent : ViewComponent
	{
		readonly ICartService _cartService;
        readonly IHttpContextAccessor _contextAccessor;
        
		public CartDtoViewComponent(ICartService cartService, IHttpContextAccessor contextAccessor)
		{
            _cartService = cartService;
            _contextAccessor = contextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CartDto? cartDto = new();
            var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity?.FindFirst("sub");
            var userId = userDataClaim?.Value;
            ResponseDto? response = await _cartService.GetCartByUserIdAsnyc(userId);
            if (response != null & response.IsSuccess)
            {
                cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
                cartDto.NumberOfCartItems = (int)cartDto.CartDetails?.Count();
            }
            return View(cartDto);
        }
    }
}
