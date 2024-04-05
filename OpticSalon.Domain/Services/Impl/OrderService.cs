using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResultWithData<Order>> CreateOrder(Recipe recipe, Frame frame, Color frameColor,
            LensPackage lens, string contactPhoneNumber, string? comment, Client client)
        {
            try
            {
                var newOrder = new Order()
                {
                    Recipe = recipe,
                    LensPackage = lens,
                    Frame = frame,
                    FrameColor = frameColor,
                    ContactPhoneNumber = contactPhoneNumber,
                    Comment = comment,
                    Client = client,
                    CreatedDate = DateTime.Now
                };

                var createdOrderId = await _orderRepository.AddOrder(newOrder);

                return new ResultWithData<Order>()
                {
                    Success = true,
                    Description = $"Заказ успешно создан! Номер заказа - {createdOrderId}"
                };
            }
            catch
            {
                return new ResultWithData<Order>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<Order>> GetOrderById(int id)
        {
            try
            {
                var res = await _orderRepository.GetOrderById(id);

                if (res == null)
                {
                    return new ResultWithData<Order>()
                    {
                        Success = false,
                        Description = "Не найдено"
                    };
                }

                return new ResultWithData<Order>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<Order>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<List<OrderShort>>> GetOrdersByClient(int clientId)
        {
            try
            {
                var res = await _orderRepository.GetOrdersByClient(clientId);

                return new ResultWithData<List<OrderShort>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<OrderShort>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public decimal GetOrderTotalCost(Order order)
        {
            return order.Frame.Cost + order.LensPackage.Cost;
        }
    }
}
