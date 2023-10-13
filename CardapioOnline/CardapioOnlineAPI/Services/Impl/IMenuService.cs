using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Entities;


namespace CardapioOnlineAPI.Services.Impl
{
    public interface IMenuService
    {
        List<MenuItem> GetAllMenuItems();
        void AddMenuItem(CreateRequest createRequest);
        MenuItem GetMenuItemById(int id);
        void UpdateMenuItem(int id, UpdateRequest updateRequest);
        void DeleteMenuItem(int id);
        Task<MenuItem> UploadImage(int id, IFormFile file);
    }
}
