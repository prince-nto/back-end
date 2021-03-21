using ControllerApp.TempModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerApp.Dto.Users
{
    public class CompanyUserDto
    {
        public int CompanyUserId { get; set; }
        public int CompanyId { get; set; }
        public  CompanyDto Company { get; set; }
        public int UserId { get; set; }
        public  UserDto User { get; set; }
    }
}
