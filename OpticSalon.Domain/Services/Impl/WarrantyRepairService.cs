using OpticSalon.Domain.Consts;
using OpticSalon.Domain.Enums;
using OpticSalon.Domain.ErrorMessages;
using OpticSalon.Domain.Models;
using OpticSalon.Domain.Repositories;
using OpticSalon.Domain.ResultModels;
using OpticSalon.Domain.SuccessMessages;

namespace OpticSalon.Domain.Services.Impl
{
    public class WarrantyRepairService : IWarrantyRepairService
    {
        private readonly IWarrantyRepairRepository _repairRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEmployeeService _employeeService;

        public WarrantyRepairService(IWarrantyRepairRepository repairRepository, IOrderRepository orderRepository, IEmployeeService employeeService)
        {
            _repairRepository = repairRepository;
            _employeeService = employeeService;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResult> CanCreateWarrantyRepair(int orderId)
        {
            var existRepaires = await _repairRepository.GetRepairesByOrder(orderId);

            if (existRepaires.FirstOrDefault(x => x.Status != OrderStatus.Issued) != null)
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = WarrantyRepairServiceMessages.AlreadyExistActiveWarrantyRepair
                };
            }

            var existWarrantyRepairesDaysCount = 0;

            foreach (var repair in existRepaires)
            {
                existWarrantyRepairesDaysCount += ((DateTime)repair.IssueDate! - repair.CreatedDate).Days;
            }

            var order = await _orderRepository.GetOrderById(orderId);

            var warrantyDate = ((DateTime)order!.IssueDate!).AddDays(WarrantyRepairConsts.WarrantyRepairPeriod + existWarrantyRepairesDaysCount);

            if (warrantyDate < DateTime.Now)
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = WarrantyRepairServiceMessages.WarrantyRepairPeriodExpired
                };
            }

            return new BaseResult()
            {
                Success = true
            };
        }

        public async Task<ResultWithData<int>> CreateRepair(int orderId, Defect defect, string? comment)
        {
            try
            {
                var availableMasterRes = await _employeeService.GetMasterForOrderAsync();

                if (!availableMasterRes.Success)
                {
                    return new ResultWithData<int>()
                    {
                        Success = false,
                        Description = availableMasterRes.Description
                    };
                }

                var newRepair = new WarrantyRepair()
                {
                    OrderId = orderId,
                    Defect = defect,
                    Comment = comment,
                    CreatedDate = DateTime.Now,
                    Master = availableMasterRes.Data!,
                    Status = Enums.OrderStatus.Created
                };

                var createdRepairId = await _repairRepository.AddWarrantyRepair(newRepair);

                return new ResultWithData<int>()
                {
                    Success = true,
                    Description = $"Гарантийный ремонт успешно оформлен! " +
                    $"Для выполнения ремонта назначен мастер {availableMasterRes.Data!.Surname} {availableMasterRes.Data!.Name}",
                    Data = createdRepairId
                };
            }
            catch
            {
                return new ResultWithData<int>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<WarrantyRepair>> GetRepairById(int id)
        {
            try
            {
                var res = await _repairRepository.GetWarrantyRepairById(id);

                if (res == null)
                {
                    return new ResultWithData<WarrantyRepair>()
                    {
                        Success = false,
                        Description = "Не найдено"
                    };
                }

                return new ResultWithData<WarrantyRepair>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<WarrantyRepair>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<List<WarrantyRepairForClient>>> GetRepairesByClient(int clientId)
        {
            try
            {
                var res = await _repairRepository.GetWarrantyRepairsByClient(clientId);

                return new ResultWithData<List<WarrantyRepairForClient>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<WarrantyRepairForClient>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<ResultWithData<List<WarrantyRepairForManager>>> GetRepairesForManager()
        {
            try
            {
                var res = await _repairRepository.GetWarrantyRepairsForManager();

                return new ResultWithData<List<WarrantyRepairForManager>>()
                {
                    Success = true,
                    Data = res
                };
            }
            catch
            {
                return new ResultWithData<List<WarrantyRepairForManager>>()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            }
        }

        public async Task<bool> IsClientRepair(int clientId, int repairId)
        {
            try
            {
                var res = await _repairRepository.IsClientRepair(clientId, repairId);

                return res;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BaseResult> UpdateRepair(WarrantyRepair repair)
        {
            try
            {
                if (repair.Status == OrderStatus.Completed && repair.Works.Count == 0)
                {
                    return new BaseResult()
                    {
                        Success = false,
                        Description = WarrantyRepairServiceMessages.WorksNotSpecified
                    };
                }

                if (repair.Status == OrderStatus.Issued)
                {
                    repair.IssueDate = DateTime.Now;
                }
                else
                {
                    repair.IssueDate = null;
                }

                await _repairRepository.UpdateWarrantyRepair(repair);

                return new BaseResult()
                {
                    Success = true,
                    Description = WarrantyRepairServiceMessages.SuccessUpdated
                };
            }
            catch
            {
                return new BaseResult()
                {
                    Success = false,
                    Description = DefaultErrors.ServerError
                };
            };
        }
    }
}
