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
		ValidateAudience = true,   // olu�turulacak token de�erini kimlerin hangi kullanc�lar�n hangi sitelerin kullanac���n�
		ValidateIssuer = true,      // olu�turulacak token de�erini kimin da��tt���n� ifade edece�imiz aland�r
		ValidateLifetime = true,        // olu�turulan token de�erinin s�resini kontrol eden aland�r
		ValidateIssuerSigningKey = true,    // �retilecek token de�erinin uygulamam�za ait bir de�er olan security key verisinin do�rulanmas�d�r

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
