using OpticSalon.Domain.ResultModels;

namespace OpticSalon.Domain.Services
{
    public interface IClientService
    {
        public Task<BaseResult> CreateClient(string login, string password, string name, 
                                    string surname, string phoneNumber, string address);
    }
}
