using App.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;

namespace App.Entities.Identity
{
 
    public class UserClaim : IdentityUserClaim<int>, IAuditableEntity
    {
        public virtual User User { get; set; }
    }
}