using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCart.Web.Models;
using ShoppingCart.Web.Repository;

namespace ShoppingCart.Web.Controllers
{
    public class CoupenController : Controller
    {
        private readonly ICoupenService _coupenService;

        public CoupenController(ICoupenService coupenService)
        {
            this._coupenService = coupenService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CoupenDto>? coupensList = new();
            ResponseDto? responseDto = await this._coupenService.GetAllCoupens();
            if(responseDto != null && responseDto.IsSuccess)
            {
                coupensList = JsonConvert.DeserializeObject<List<CoupenDto>>(responseDto?.Result?.ToString());
            }
            else{
                TempData["error"]="Error occurred!!";
            }
            return View(coupensList);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCoupen()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupen(CoupenDto coupenDto)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? responseDto = await this._coupenService.GetAllCoupens();
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"]="Coupen created successfully!!";
                    return RedirectToAction("Index");
                }
                else{
                TempData["error"]="Error occurred!!";
                }
            }
            return View(coupenDto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCoupen(int coupenId)
        {
            ResponseDto? responseDto = await this._coupenService.GetCoupenByIDAsync(coupenId);
            if (responseDto != null && responseDto.IsSuccess)
            {
               var coupensList = JsonConvert.DeserializeObject<CoupenDto>(responseDto?.Result?.ToString());
                return View(coupensList);
            }
            
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCoupen(CoupenDto coupenDto)
        {
            ResponseDto? responseDto = await this._coupenService.DeleteCoupenAsync(coupenDto.CoupenId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"]="Coupen deleted successfully!!";
                return RedirectToAction("Index");
            }
            else{
                TempData["error"]="Error occurred!!";
                }
            return View(coupenDto);
        }
    }
}
