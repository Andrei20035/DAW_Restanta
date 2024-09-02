using DAW_Restanta.Models;

namespace DAW_Restanta.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync();
        Task<ShoppingCart> GetShoppingCartByIdAsync(int cartId);
        Task AddShoppingCartAsync(ShoppingCart shoppingCart);
        Task UpdateShoppingCartAsync(ShoppingCart shoppingCart);
        Task DeleteShoppingCartAsync(int cartId);
    }
}
