using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDto>> GetUserData();
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> UpdateUserData(GetUserDto updateUser);

        Task<ServiceResponse<List<GetUserDto>>> AddUserData(GetUserDto newUser);
    }
}