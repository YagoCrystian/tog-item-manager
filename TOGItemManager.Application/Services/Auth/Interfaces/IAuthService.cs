using TOGItemManager.Application.DTOs.Auth.Requests;
using TOGItemManager.Application.DTOs.Auth.Responses;

namespace TOGItemManager.Application.Services.Auth.Interfaces
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);
    }
}