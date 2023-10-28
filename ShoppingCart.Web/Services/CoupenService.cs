using ShoppingCart.Web.Models;
using ShoppingCart.Web.Repository;
using ShoppingCart.Web.Utility;
using static ShoppingCart.Web.Utility.SharedComponent;

namespace ShoppingCart.Web.Services
{
    public class CoupenService : ICoupenService
    {
        private readonly IBaseService _baseService;

        public CoupenService(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        public async Task<ResponseDto?> CreateCoupenAsync(CoupenDto coupen)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = ApiType.Post,
                Url = SharedComponent.CoupenAPIBase + "/api/Coupen/CreateCoupen",
                Data = coupen
            });
        }

        public async Task<ResponseDto?> DeleteCoupenAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = ApiType.Delete,
                Url = SharedComponent.CoupenAPIBase + "/api/Coupen/DeleteCoupen/"+id,
            });
        }

        public async Task<ResponseDto?> GetAllCoupens()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = ApiType.Get,
                Url = SharedComponent.CoupenAPIBase + "/api/Coupen/getCoupes"
            });
        }

        public async Task<ResponseDto?> GetCoupenByCodeAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = ApiType.Get,
                Url = SharedComponent.CoupenAPIBase + "/api/Coupen/GetCoupenByCode/"+name
            });
        }

        public async Task<ResponseDto?> GetCoupenByIDAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = ApiType.Get,
                Url = SharedComponent.CoupenAPIBase + "/api/Coupen/GetCoupenByID/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCoupenAsync(CoupenDto coupen)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = ApiType.Put,
                Url = SharedComponent.CoupenAPIBase + "/api/Coupen/UpdateCoupen",
                Data = coupen
            });
        }
    }
}
