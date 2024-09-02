using DAW_Restanta.Models;

namespace DAW_Restanta.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync();
        Task<ShoppingCart> GetShoppingCartByIdAsync(int cartId);
        Task AddShoppingCartAsync(ShoppingCart shoppingCart);
        Task UpdateShoppingCartAsync(ShoppingCart shoppingCart);
        Task DeleteShoppingCartAsync(int cartId);
    }
}
