﻿namespace Library.Application.Middleware
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // Admin , User
    }
}
