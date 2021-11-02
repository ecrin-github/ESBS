using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Models.User
{
    [Table("rms_users", Schema = "users")]
    public class RmsUser : IdentityUser
    {
        
    }
}