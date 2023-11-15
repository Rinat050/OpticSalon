﻿using OpticSalon.Domain.Models;
using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IFrameService
    {
        public Task<ResultWithData<List<FrameShort>>> GetAllFrames();
        public Task<ResultWithData<Frame>> GetFrameById(int id);
        public Task<ResultWithData<List<FrameShort>>> GetAllFrames(int? typeId, int? materialId, int? colorId, 
                                                    int? genderId, int? brandId, ClientPreferences? clientPreferences);
    }
}
