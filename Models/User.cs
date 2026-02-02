using Microsoft.AspNetCore.Identity;
/// <summary>
/// class representing a user or a member of the IT support team
/// </summary>
public class User : IdentityUser
{
    public string Pseudo {get; set;}
}