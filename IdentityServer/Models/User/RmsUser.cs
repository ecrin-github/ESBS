using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models.User
{
    [Table("rms_users", Schema = "users")]
    public class RmsUser : IdentityUser
    {
        
    }
}