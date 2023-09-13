using App.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;

namespace App.Entities.Identity
{
 
    public class UserRole : IdentityUserRole<int>, IAuditableEntity
    {
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}