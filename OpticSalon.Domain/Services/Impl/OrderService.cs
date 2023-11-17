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
            LensPackage lens, int lensTintingPercent, string contactPhoneNumber, string deliveryAddress,
            string comment, Client client)
        {
            try
            {
                var newOrder = new Order()
                {
                    Recipe = recipe,
                    LensPackage = lens,
                    Frame = frame,
                    FrameColor = frameColor,
                    DeliveryAddress = deliveryAddress,
                    ContactPhoneNumber = contactPhoneNumber,
                    Comment = comment,
                    Client = client,
                    LensTintingPercent = lensTintingPercent,
                    CreatedDate = DateTime.Now
                };

                var createdOrder = await _orderRepository.AddOrder(newOrder);

                return new ResultWithData<Order>()
                {
                    Success = true,
                    Description = $"Заказ успешно создан! Номер заказа - {createdOrder.Id}"
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

        public decimal GetOrderTotalCost(Order order)
        {
            return order.Frame.Cost + order.LensPackage.Cost;
        }
    }
}
