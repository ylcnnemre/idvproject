using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movie.Application.Features.Command.User.LoginUser;
using Movie.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
	private readonly SignInManager<AppUser> signInManager;
	private readonly UserManager<AppUser> userManager;
	private readonly IConfiguration configuration;

	public LoginUserCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
	{
		this.signInManager = signInManager;
		this.userManager = userManager;
		this.configuration = configuration;
	}

	public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByEmailAsync(request.Email);
		if (user == null)
		{
			return new LoginUserCommandResponse { ErrorMessage = "Geçersiz kullanıcı adı veya şifre.", Succeeded = false };
		}

		var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
		if (!result.Succeeded)
		{
			return new LoginUserCommandResponse { ErrorMessage = "Geçersiz kullanıcı adı veya şifre.", Succeeded = false };
		}

		var token = GenerateJwtToken(user);

		return new LoginUserCommandResponse { Token = token, Succeeded = true };
	}

	private string GenerateJwtToken(AppUser user)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]);

		var roles = userManager.GetRolesAsync(user).Result; // Kullanıcının rollerini al

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Audience = configuration["Token:Audince"],
			Issuer = configuration["Token:Issuer"],
			Expires = DateTime.UtcNow.AddMinutes(30),
			NotBefore = DateTime.UtcNow,
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
			Subject = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
			}),
			Claims = new Dictionary<string, object>
			{
				{ "roles", roles }
			}
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		var tokenString = tokenHandler.WriteToken(token);

		return tokenString;
	}
}
