using ShoppingCart.Web.Utility;
using static ShoppingCart.Web.Utility.SharedComponent;

namespace ShoppingCart.Web.Models
{
    public class RequestDto
    {
        public ApiType RequestType { get; set; } = ApiType.Get;
        public string? Url { get; set; }
        public object? Data { get; set; }
        public string?  AccessToken { get; set; }
    }
}
