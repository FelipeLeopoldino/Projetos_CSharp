using CardapioOnlineAPI.Entities;

namespace CardapioOnlineAPI.Dto
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }

        public static MenuItem FromUpdateRequest(UpdateRequest request)
        {
            return new MenuItem
            {
                Description = request.Description,
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                ImageUrl = request.ImageUrl

            };
        }

        public static UpdateRequest FromMenuItem(MenuItem menuItem)
        {
            return new UpdateRequest
            {
                Description = menuItem.Description,
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price,
                ImageUrl = menuItem.ImageUrl

            };
        }
    }
}
