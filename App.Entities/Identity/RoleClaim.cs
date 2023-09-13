using App.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;

namespace App.Entities.Identity
{
  
    public class RoleClaim : IdentityRoleClaim<int>, IAuditableEntity
    {
        public virtual Role Role { get; set; }
    }
}