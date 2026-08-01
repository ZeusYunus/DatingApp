using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

// DTOs is when you send data from the client to the backend using the json body

public class RegisterDto
{
    [Required]
    public string DisplayName { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [MinLength(4)]
    public string Password { get; set; } = "";

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;

    [Required]
    public DateOnly DateOfBirth { get; set; }
}
