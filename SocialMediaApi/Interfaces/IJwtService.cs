using SocialMediaApi.Models;

namespace SocialMediaApi.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}