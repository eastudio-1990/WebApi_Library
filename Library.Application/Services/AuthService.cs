using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || !_passwordHasher.VerifyPassword(password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid cRedentials.");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["MojoJwt:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["MojoJwt:Audience"])
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MojoJwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task RegisterAsync(string email, string password, string name, string role)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser != null)
                throw new InvalidOperationException("User already exists.");

            // Hash the password
            var hashedPassword = _passwordHasher.HashPassword(password);

            var newUser = new User
            {
                Email = email,
                PasswordHash = hashedPassword,
                Name = name,
                Role = role,
            };

            await _userRepository.AddAsync(newUser);
        }
    }
}
