using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Infrastructure;
using Library.Infrastructure.Config;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

#region DataBase Config Tunnel
// v

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MojCon")));

// ^
#endregion DataBase Config Tunnel

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureJwtAuthentication(configuration);

// Moved to AuthService v

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(opt =>
//    {
//        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//        {
//            ValidIssuer = configuration["MojoJwt:Issuer"],
//            ValidAudience = configuration["MojoJwt:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["MojoJwt:SecretKey"]))
//        };
//    });

// Moved to AuthService ^

builder.Services.AddScoped<AuthService>();

builder.Services.AddSwaggerGen();

#region Services
// v

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IBorrowerRepository, BorrowerRepository>();
builder.Services.AddScoped<IBorrowerService, BorrowerService>();

builder.Services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
builder.Services.AddScoped<IBorrowRecordService, BorrowRecordService>();

// ^
#endregion Services

#region Security

// Data Protection v

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:/.../Keys"))
    .SetApplicationName("MojoGemLibrary");

// Data Protection ^


// Event Logger v

builder.Host.UseSerilog((context, configuration) => 
configuration.ReadFrom.Configuration(context.Configuration));

// Event Logger ^


// Rate Limiting v

builder.Services.AddInMemoryRateLimiting();

builder.Services.Configure<IpRateLimitOptions>(options =>
{
    options.GeneralRules = new List<RateLimitRule>
    {
        new RateLimitRule
        {
            Endpoint = "*",
            Period = "1m",
            Limit = 100
        }
    };
});
// Rate Limiting ^

#endregion Security

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
