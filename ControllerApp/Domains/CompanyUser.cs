using ControllerApp.Domains.Users;

namespace TenderSystem.Models
{
    public class CompanyUser
    {
        public int CompanyUserId { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
