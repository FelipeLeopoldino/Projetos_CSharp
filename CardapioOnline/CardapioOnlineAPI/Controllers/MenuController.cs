using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Entities;
using CardapioOnlineAPI.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _ImenuService;

        public MenuController(IMenuService menuService)
        {
            _ImenuService = menuService;
        }

        [HttpGet]
        public IActionResult GetAllMenuItems()
        {
            var resposta = _ImenuService.GetAllMenuItems();

            if (resposta == null)
            {
                return new NotFoundResult();
            }

            return Ok(resposta);
        }

        [HttpPost]
        public void AddMenuItem([FromBody] CreateRequest createRequest)
        {
            _ImenuService.AddMenuItem(createRequest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatemenuItem(int id, [FromBody] UpdateRequest updateRequest)
        {
            if (id != updateRequest.Id)
            {
                return BadRequest();
            }

            _ImenuService.UpdateMenuItem(id, updateRequest);

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuItemById(int id)
        {
            var menuItem = _ImenuService.GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItemById(int id)
        {
            var menuItem = GetMenuItemById(id);

            if (menuItem == null)
            {
                return NotFound(id);
            }

            _ImenuService.DeleteMenuItem(id);

            return NoContent();
        }

        [HttpPost("{id}/upload/")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            await _ImenuService.UploadImage(id, file);

            return Ok();
        }
    }
}
