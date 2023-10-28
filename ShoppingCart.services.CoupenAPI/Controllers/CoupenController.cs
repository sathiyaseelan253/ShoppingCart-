using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.services.CoupenAPI.Data;
using ShoppingCart.services.CoupenAPI.Models;
using ShoppingCart.services.CoupenAPI.Models.Dto;

namespace ShoppingCart.services.CoupenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoupenController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private ResponseDto response;

        public CoupenController(AppDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
            this.response = new ResponseDto();
        }
        [Route("getCoupes")]
        [HttpGet]
        public ResponseDto GetCoupes()
        {
            try
            {
                IEnumerable<Coupen> coupens = _db.Coupen.ToList();
                response.Result = _mapper.Map<IEnumerable<CoupenDto>>(coupens);
                response.Error = coupens?.Count() > 0 ? string.Empty : "No coupens available!!";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Error = ex.Message;
            }
            return response;
        }
        [Route("GetCoupenByID/{id:int}")]
        [HttpGet]
        public ResponseDto GetCoupenByID(int id)
        {
            try
            {
                Coupen? coupen = _db.Coupen.First(tempCoupen=> tempCoupen.CoupenId == id);
                response.Result = _mapper.Map<CoupenDto>(coupen);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Error = ex.Message;
            }
            return response;
        }
        [HttpGet]
        [Route("GetCoupenByCode/{name}")]
        public ResponseDto GetCoupenByCode(string name)
        {
            try
            {
                Coupen coupen = _db.Coupen.First(temp => temp.CoupenCode.ToLower() == name.ToLower());
                response.Result = _mapper.Map<CoupenDto>(coupen);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Error = ex.Message;
            }
            return response;
        }
        [HttpPost]
        [Route("CreateCoupen")]
        public ResponseDto Create([FromBody]CoupenDto coupen)
        {
            try
            {

                if (coupen != null)
                {
                    Coupen coupenToAdd = _mapper.Map<Coupen>(coupen); 
                    _db.Coupen.Add(coupenToAdd);
                    _db.SaveChanges();
                    response.Result = coupen;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Error = ex.Message;
            }
            return response;
        }
        [HttpPut]
        [Route("UpdateCoupen")]
        public ResponseDto Update([FromBody]CoupenDto coupenDto)
        {
            try
            {
                Coupen coupen = _mapper.Map<Coupen>(coupenDto);
                _db.Coupen.Update(coupen);
                _db.SaveChanges();
                response.Result = coupenDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Error = ex.Message;
            }
            return response;
        }
        [HttpDelete]
        [Route("DeleteCoupen/{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupen coupen = _db.Coupen.First(temp=>temp.CoupenId == id);    
                _db.Remove(coupen);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Error = ex.Message;
            }
            return response;
        }
    }
}
