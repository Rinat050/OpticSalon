using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IOrderService
    {
        public Task<ResultWithData<Order>> CreateOrder(Recipe recipe, Frame frame, Color frameColor, 
            LensPackage lens, string contactPhoneNumber, string? comment, Client client);

        public Task<ResultWithData<List<OrderShortForClient>>> GetOrdersByClient(int clientId);
        public Task<ResultWithData<List<OrderShortForManager>>> GetOrdersForManager();
        public Task<ResultWithData<Order>> GetOrderById(int id);
        public Task<BaseResult> UpdateOrder(Order order);
        public decimal GetOrderTotalCost(Order order);
    }
}
