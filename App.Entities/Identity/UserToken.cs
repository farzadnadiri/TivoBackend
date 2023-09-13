using App.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;

namespace App.Entities.Identity
{
    
    public class UserToken : IdentityUserToken<int>, IAuditableEntity
    {
        public virtual User User { get; set; }
    }
}