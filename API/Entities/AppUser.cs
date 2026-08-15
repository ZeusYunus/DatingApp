using Microsoft.AspNetCore.Identity;

namespace API.Entities;

//  Entity classes typically relates to tables in a databases. Below is the columns in the table
public class AppUser : IdentityUser
{
    public required string DisplayName { get; set; }
    public string? ImageUrl { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }

    // Nav property
    public Member Member { get; set; } = null!;
}