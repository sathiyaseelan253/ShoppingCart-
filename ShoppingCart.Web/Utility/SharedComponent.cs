namespace ShoppingCart.Web.Utility
{
    public class SharedComponent
    {
        public static string CoupenAPIBase { get; set; }
        public enum ApiType
        {
            Get,
            Post,
            Put,
            Delete,
        }
    }
   
}
