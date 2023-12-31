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
		ValidateAudience = true,   // oluşturulacak token değerini kimlerin hangi kullancıların hangi sitelerin kullanacığını
		ValidateIssuer = true,      // oluşturulacak token değerini kimin dağıttığını ifade edeceğimiz alandır
		ValidateLifetime = true,        // oluşturulan token değerinin süresini kontrol eden alandır
		ValidateIssuerSigningKey = true,    // üretilecek token değerinin uygulamamıza ait bir değer olan security key verisinin doğrulanmasıdır

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
