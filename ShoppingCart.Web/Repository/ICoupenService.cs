using ShoppingCart.Web.Models;

namespace ShoppingCart.Web.Repository
{
    public interface ICoupenService
    {
        Task<ResponseDto?> GetAllCoupens();
        Task<ResponseDto?> GetCoupenByIDAsync(int id);
        Task<ResponseDto?> GetCoupenByCodeAsync(string name);
        Task<ResponseDto?> CreateCoupenAsync(CoupenDto coupen);
        Task<ResponseDto?> UpdateCoupenAsync(CoupenDto coupen);
        Task<ResponseDto?> DeleteCoupenAsync(int id);

    }
}
