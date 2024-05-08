

namespace BackendServices.Core
{
    public interface IServices <TRequest, TResponse, TDataReponse>
    where TRequest : IServicesRequest
    where TResponse : IServicesResponse<TDataReponse>
    {
        ValueTask<TResponse> ExecuteAsync(TRequest request);
        ValueTask<IEnumerable<string>> ValidateAsync(TRequest request);
    }


    public interface IServicesRequest
    {

    }

    public interface IServicesResponse<T>
    {
         string Message { get; set; }
         IEnumerable<string>? Errors { get; set; }
         bool Success { get; set; }
         abstract T Data { get; set;}

    }
}