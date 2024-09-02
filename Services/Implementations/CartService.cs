using DAW_Restanta.Models;
using DAW_Restanta.Repositories.Interfaces;
using DAW_Restanta.Services.Interfaces;

namespace DAW_Restanta.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync()
        {
            return await _shoppingCartRepository.GetAllShoppingCartsAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int cartId)
        {
            return await _shoppingCartRepository.GetShoppingCartByIdAsync(cartId);
        }

        public async Task AddShoppingCartAsync(ShoppingCart shoppingCart)
        {
            await _shoppingCartRepository.AddShoppingCartAsync(shoppingCart);
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            await _shoppingCartRepository.UpdateShoppingCartAsync(shoppingCart);
        }

        public async Task DeleteShoppingCartAsync(int cartId)
        {
            await _shoppingCartRepository.DeleteShoppingCartAsync(cartId);
        }
    }
}
