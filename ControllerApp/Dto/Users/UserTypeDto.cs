
using AutoMapper;
using ControllerApp.Domains.Users;

namespace ControllerApp.TempModels.Users
{
    [AutoMap(typeof(UserType))]
    public class UserTypeDto
    {
        public int UserTypeId { get; set; }
        public string Name { get; set; }
    }
}
