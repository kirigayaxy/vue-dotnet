using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dotnet.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
                 .FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<GetUserDto>> GetUserData()
        {
            var response = new ServiceResponse<GetUserDto>();
            var userId = GetUserId();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                response.Data = _mapper.Map<GetUserDto>(user);
            }
            else
            {
                response.Success = false;
                response.Message = "User not found";
            }

            return response;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var response = new ServiceResponse<List<GetUserDto>>();
            var users = await _context.Users.ToListAsync();
            response.Data = users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            return response;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> AddUserData(GetUserDto newUser)
        {
            var response = new ServiceResponse<List<GetUserDto>>();
            var user = _mapper.Map<Users>(newUser);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = await _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync();
            return response;

        }
        public async Task<ServiceResponse<GetUserDto>> UpdateUserData(GetUserDto updateUser)
        {
            var response = new ServiceResponse<GetUserDto>();
            var userId = GetUserId();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User Not found";
                return response;
            }
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Role = updateUser.Role;
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetUserDto>(user);
            return response;

        }
    }
}