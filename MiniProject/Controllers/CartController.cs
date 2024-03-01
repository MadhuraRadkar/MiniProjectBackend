using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Model;
using MiniProject.Services;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService service;
        public CartController(ICartService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetCart/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var list = await service.GetCart(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> Post([FromBody][Bind(include:"Id,Rid")] Cart cart)
        {

            try
            {
                var result = await service.AddToCart(cart);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpDelete]
        [Route("DeleteFromCart/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteFromCart(id);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}

