using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Dtos
{
    public class AddUserDto
    {
        public string FirstName { get; set; }= string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } =string.Empty;
    }
}