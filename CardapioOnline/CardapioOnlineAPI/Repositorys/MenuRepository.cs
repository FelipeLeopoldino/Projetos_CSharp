using CardapioOnlineAPI.Entities;
using CardapioOnlineAPI.Repositorys.Impl;

namespace CardapioOnlineAPI.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private static List<MenuItem> _menuItems = new List<MenuItem>();

        public void AddMenuItem(MenuItem menuItem)
        {
            menuItem.Id = _menuItems.Count + 1;
            _menuItems.Add(menuItem);
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItems;
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _menuItems.FirstOrDefault(item => item.Id == id);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            var menuItemOld = _menuItems.FirstOrDefault(i => i.Id == menuItem.Id);

            menuItemOld.Name = menuItem.Name;
            menuItemOld.Description = menuItem.Description;
            menuItemOld.Price = menuItem.Price;
            menuItemOld.ImageUrl = menuItem.ImageUrl;
        }

        public void DeleteMenuItem(int id)
        {
            var existingItem = _menuItems.FirstOrDefault(item => item.Id == id);
            if (existingItem != null)
            {
                _menuItems.Remove(existingItem);
            }
        }
    }
}
