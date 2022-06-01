namespace UserService.Models.User;

#nullable enable
public class User
{
    public string? Sub { get; set; }
    public string? Name { get; set; }
    public string? PreferredUsername { get; set; }
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
    public string? Email { get; set; }
    public bool? EmailVerified { get; set; }
}