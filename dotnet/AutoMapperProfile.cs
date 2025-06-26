using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetUserDto, Users>();

            CreateMap<Users, GetUserDto>();
            CreateMap<AddUserDto, Users>();
        }
    }
}