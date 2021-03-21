using System;
using System.ComponentModel.DataAnnotations;

namespace ControllerApp.TempModels.Users
{
    public class UserDto
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CellPhonenumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserTypeId { get; set; }
        public UserTypeDto UserType { get; set; }
    }
}
