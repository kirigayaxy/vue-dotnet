using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Users user, string password);

        Task<ServiceResponse<string>> Login(string username, string password);
    }
}