using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Features.Command.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
	{
		private readonly UserManager<AppUser> userManager;
		private readonly RoleManager<AppRole> roleManager;
		public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
		{
			var user = new AppUser
			{
				UserName = request.Username,
				Email = request.Email
			};

			var result = await userManager.CreateAsync(user, request.Password);
			if (!result.Succeeded)
			{
				return new CreateUserCommandResponse { ErrorMessage = "Kullanıcı oluşturulamadı.", Succeeded = false };
			}

			if (!await roleManager.RoleExistsAsync(request.Role))
			{
				await roleManager.CreateAsync(new AppRole() { Name= request.Role }  );
			}

			await userManager.AddToRoleAsync(user, request.Role);

			return new CreateUserCommandResponse { Succeeded = true };
		}
	}
}
