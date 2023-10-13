using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Entities;
using CardapioOnlineAPI.Repository;
using CardapioOnlineAPI.Repositorys.Impl;
using CardapioOnlineAPI.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnlineAPI.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _IMenuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _IMenuRepository = menuRepository;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _IMenuRepository.GetAllMenuItems();
        }

        public void AddMenuItem(CreateRequest createRequest)
        {
            var menuItem = new MenuItem()
            {
                Description = createRequest.Description,
                Name = createRequest.Name,
                Price = createRequest.Price,
            };

            _IMenuRepository.AddMenuItem(menuItem);
        }

        public MenuItem GetMenuItemById(int id)
        {
            var retorno = _IMenuRepository.GetMenuItemById(id);
            return retorno;
        }

        public void UpdateMenuItem(int id, UpdateRequest updateRequest)
        {
            var exist = GetMenuItemById(id);

            var menuItem = UpdateRequest.FromUpdateRequest(updateRequest);

            if (exist != null)
            {
                _IMenuRepository.UpdateMenuItem(menuItem);
            }
        }

        public void DeleteMenuItem(int id)
        {
            _IMenuRepository.DeleteMenuItem(id);
        }

        public async Task<MenuItem> UploadImage(int id, IFormFile file)
        {

            var menuItem = GetMenuItemById(id);

            if (menuItem == null)
            {
                throw new Exception("Menu não localizado");
            }

            if (file == null)
            {
                throw new Exception("Arquivo vazio ou chamada errada");
            }

            string uploadsFolder = Path.Combine(@"C:\FelipeLeopoldino\projetos\Projetos_CSharp\CardapioOnline\CardapioOnlineAPI\upload");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            menuItem.ImageUrl = filePath;
            UpdateMenuItem(id, UpdateRequest.FromMenuItem(menuItem));

            return menuItem;
        }
    }
}
