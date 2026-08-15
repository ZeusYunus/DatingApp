using System;
using API.Entities;

namespace API.Interfaces;

// The idea of an interface is we're abstracted away from the implementation. So how CreateToken method is not important we just want the output

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
    string GenerateRefreshToken();
}
