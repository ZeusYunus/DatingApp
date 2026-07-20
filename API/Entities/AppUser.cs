namespace API.Entities;

//  Entity classes typically relates to tables in a databases. Below is the columns in the table
public class AppUser
{
    public required string Id { get; set; } = Guid.NewGuid().ToString();
    public required string DisplayName { get; set; }
    public required string Email { get; set; }
}
