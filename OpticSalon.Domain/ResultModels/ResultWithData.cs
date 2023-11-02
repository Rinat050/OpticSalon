namespace OpticSalon.Domain.ResultModels
{
    public class ResultWithData<T>: BaseResult
    {
        public T? Data { get; set; }
    }
}
