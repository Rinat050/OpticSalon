using OpticSalon.Domain.Enums;
using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;
using OpticSalon.Domain.SuccessMessages;

namespace OpticSalon.Domain.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmployeeService _employeeService;

        public OrderService(IOrderRepository orderRepository, IEmployeeService employeeService)
        {
            _orderRepository = orderRepository;
            _employeeService = employeeService;
        }

        public async Task<ResultWithData<Order>> CreateOrder(Recipe recipe, Frame frame, Color frameColor,
            LensPackage lens, string contactPhoneNumber, string? comment, Client client)
        {
            try
            {
                var availableMasterRes = await _employeeService.GetMasterForOrderAsync();

                if (!availableMasterRes.Success)
                {
                    return new ResultWithData<Order>()
                    {
                        Success = false,
                        Description = availableMasterRes.Description
                    };
                }

                var newOrder = new Order()
                {
                    Recipe = recipe,
                    LensPackage = lens,
                    Frame = frame,
                    FrameColor = frameColor,
                    ContactPhoneNumber = contactPhoneNumber,
                    Comment = comment,
                    Client = client,
                    CreatedDate = DateTime.Now,
                    Master = availableMasterRes.Data!,
                    Status = Enums.OrderStatus.Created
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

        public async Task<ResultWithData<List<OrderShortForClient>>> GetOrdersByClient(int clientId)
        {
            try
            {
                var res = await _orderRepository.GetOrdersByClient(clientId);

                return new ResultWithData<List<OrderShortForClient>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<OrderShortForClient>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<List<OrderShortForManager>>> GetOrdersForManager()
        {
            try
            {
                var res = await _orderRepository.GetOrdersForManager();

                return new ResultWithData<List<OrderShortForManager>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<OrderShortForManager>>()
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

        public async Task<BaseResult> UpdateOrder(Order order)
        {
            try
            {
                if (order.Status == OrderStatus.Issued)
                {
                    order.IssueDate = DateTime.Now;
                }
                else
                {
                    order.IssueDate = null;
                }

                await _orderRepository.UpdateOrder(order);

                return new BaseResult()
                {
                    Success = true,
                    Description = OrderServiceMessages.SuccessUpdate
                };
            }
            catch
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }
    }
}
