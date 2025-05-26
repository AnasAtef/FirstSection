using FirstSection.Configurations;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("HotelListingDbString");
builder.Services.AddDbContext<FitnessDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentityCore<APIUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<FitnessDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICountryRepository,CountriesRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IFitnessCategoryRepository, FitnessCategoryRepository>();
builder.Services.AddAuthentication(options => {  

    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters 
    {
    ValidateIssuerSigningKey =true,
    ValidateIssuer=true,
    ValidateAudience=true,
    ValidateLifetime=true,
    ClockSkew=TimeSpan.Zero,
    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
    ValidAudience = builder.Configuration["JwtSettings:Audiance"],
    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])) 

    };
}
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});




var app = builder.Build();
app.UseCors("AllowAll"); // <--- add this before UseAuthorization
// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // <-- This is necessary for Swagger UI to work
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
