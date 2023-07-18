using Movie.Application;
using Movie.Persistence;
using FluentValidation.AspNetCore;
using Movie.Application.Validator;
using Movie.Application.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceService();
builder.Services.AddApplicationService();
builder.Services.AddControllers( x => x.Filters.Add<ValidationFilter>()).AddFluentValidation(config =>
{
	config.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>();
	config.RegisterValidatorsFromAssemblyContaining<LoginUserValidator>();
	config.RegisterValidatorsFromAssemblyContaining<CreateMovieValidator>();
	config.RegisterValidatorsFromAssemblyContaining<UpdateReviewValidator>();
}).ConfigureApiBehaviorOptions(config => config.SuppressModelStateInvalidFilter = true);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin", options =>
{
	options.TokenValidationParameters = new()
	{
		ValidateAudience = true,   // oluþturulacak token deðerini kimlerin hangi kullancýlarýn hangi sitelerin kullanacýðýný
		ValidateIssuer = true,      // oluþturulacak token deðerini kimin daðýttýðýný ifade edeceðimiz alandýr
		ValidateLifetime = true,        // oluþturulan token deðerinin süresini kontrol eden alandýr
		ValidateIssuerSigningKey = true,    // üretilecek token deðerinin uygulamamýza ait bir deðer olan security key verisinin doðrulanmasýdýr

		ValidAudience = builder.Configuration["Token:Audince"],
		ValidIssuer = builder.Configuration["Token:Issuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
	};
});






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
