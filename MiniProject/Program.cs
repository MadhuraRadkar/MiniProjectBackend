using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MiniProject.Data;
using MiniProject.Repositories;
using MiniProject.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/*builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    ));*/
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins(
                            "http://localhost:4200"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});


var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));

// inject the services in product
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddScoped<IRegistrationRepository,RegistrationRepository>();
builder.Services.AddScoped<IRegistrationService,RegistrationService>();

builder.Services.AddScoped<ICartRepo,CartRepo>();
builder.Services.AddScoped<ICartService,CartService>();

builder.Services.AddScoped<IOrdersRepo, OrdersRepo>();
builder.Services.AddScoped<IOrdersService, OrdersService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MiniProject", Version = "v1" });
});




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseAuthentication();
app.UseCors("AllowAngularOrigins");


app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniProject v1"));

app.Run();
