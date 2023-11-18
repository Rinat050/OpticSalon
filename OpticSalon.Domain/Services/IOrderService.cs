﻿using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IOrderService
    {
        public Task<ResultWithData<Order>> CreateOrder(Recipe recipe, Frame frame, Color frameColor, 
            LensPackage lens, int lensTintingPercent, string contactPhoneNumber, string deliveryAddress, 
            string? comment, Client client);

        public Task<ResultWithData<List<OrderShort>>> GetOrdersByClient(int clientId);
        public Task<ResultWithData<Order>> GetOrderById(int id);
    }
}
