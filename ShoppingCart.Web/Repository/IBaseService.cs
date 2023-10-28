using ShoppingCart.Web.Models;

namespace ShoppingCart.Web.Repository
{
    public interface IBaseService
    {
        public Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
