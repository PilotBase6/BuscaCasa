
namespace BackendServices.Core
{

    public interface IRegister : IServices<IRegisterRequest, IRegisterResponse, IRegisterData>
    {
    }

    public interface IRegisterRequest : IServicesRequest
    {
        string nickname { get; set; }
        string email { get; set; }
        string password { get; set; }
        string city { get; set; }
        int cellphone { get; set; }
    }

    public interface IRegisterResponse : IServicesResponse<IRegisterData>
    {

    }

    public interface IRegisterData
    {
        string Message { get; set; }
    }
}