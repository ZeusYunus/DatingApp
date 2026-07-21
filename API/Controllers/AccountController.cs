using System;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
// using | dispose of the instance for safe memory

public class AccountController(AppDbContext context) : BaseApiController
{
    [HttpPost("register")] //api/account/register
    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
    {
        if (await EmailExists(registerDto.Email)) return BadRequest("Email taken");

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };
        
        // This below method set the data to be tracked in memory
        // context = database | Users = table | user = row
        context.Users.Add(user);

        // Below method saves tracked changes to the database
        await context.SaveChangesAsync();

        return user;
    }

    private async Task<bool> EmailExists(string email)
    {
        return await context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
    }
}
