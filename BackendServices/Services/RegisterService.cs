

using BackendServices.Core;

namespace BackendServices.Services
{
    public class RegisterService : IRegister
    {
        public async ValueTask<IRegisterResponse> ExecuteAsync(IRegisterRequest request)
        {
            if (await ValidateAsync(request) is var errors && errors.Any())
            {
                return new RegisterResponse
                {
                    Message = "Validation failed",
                    Errors = errors,
                    Success = false,
                    Data = new RegisterData
                    {
                        Message = "Validation failed"
                    }
                };
            }

            

            return new RegisterResponse
            {
                Message = "User registered",
                Success = true,
                Data = new RegisterData
                {
                    Message = "User registered"
                }
            };
        }

        public async ValueTask<IEnumerable<string>> ValidateAsync(IRegisterRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.nickname))
            {
                errors.Add("Nickname is required");
            }

            if (request.nickname.Length > 20)
            {
                errors.Add("Nickname must be less than 20 characters");
            }

            return errors;
        }

    }

    public class RegisterRequest : IRegisterRequest
    {
        public string nickname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public int cellphone { get; set; }
    }

    public class RegisterResponse : IRegisterResponse
    {
        public string Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public bool Success { get; set; }
        public IRegisterData Data { get; set; }

    }

    public class RegisterData : IRegisterData
    {
        public string Message { get; set; }
    }

}