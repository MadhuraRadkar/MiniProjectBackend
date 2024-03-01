using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Model;
using MiniProject.Services;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService service;
        public OrderController(IOrdersService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("BuyNow")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "Id,Rid")] Orders orders)
        {

            try
            {
                var result = await service.BuyNow(orders);
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


        [HttpGet]
        [Route("MyOrders/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var list = await service.MyOrders(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
