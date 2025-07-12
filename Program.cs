using Assignment.Data;
using Assignment.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register ApplicationDbContext and use SQL Server for the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register TuitionClassService
builder.Services.AddScoped<TuitionClassService>();

// Setup custom cookie-based authentication
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        config.Cookie.Name = "UserLoginCookie";
        config.LoginPath = "/Login";  // Redirect to login page if not authenticated
        config.AccessDeniedPath = "/AccessDenied";  // Redirect if access is denied
        config.LogoutPath = "/Logout";  // Path to handle logout
    });

// Setup role-based authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "Admin");  // Require "Admin" role
    });

    options.AddPolicy("ParentOnly", policy => {
        policy.RequireClaim(ClaimTypes.Role, "Parent");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
