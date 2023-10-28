using AutoMapper;
using ShoppingCart.services.CoupenAPI.Models;
using ShoppingCart.services.CoupenAPI.Models.Dto;

namespace ShoppingCart.services.CoupenAPI
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupen, CoupenDto>();
                config.CreateMap<CoupenDto, Coupen>();

            });
            return mapperConfig;
        }
    }
}
