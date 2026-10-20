using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Common.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.Common.Helpers;

internal class IdentityDatabaseSeeder : IIdentityDatabaseSeeder
{
	private readonly AdminOptions _adminOptions;
	private readonly IApplicationSender _sender;
	private readonly IUserCommandRepository _repository;

	public IdentityDatabaseSeeder(
		IOptions<AdminOptions> adminOptions,
		IApplicationSender sender,
		IUserCommandRepository repository)
	{
		_adminOptions = adminOptions.Value;
		_sender = sender;
		_repository = repository;
	}

	public async Task SeedAsync(CancellationToken cancellationToken)
	{
		var nameIsNotUnique = !await _repository.IsNameUniqueAsync(new(_adminOptions.Name), cancellationToken);
		var emailIsNotUnique = !await _repository.IsEmailUniqueAsync(new(_adminOptions.Email), cancellationToken);

		if (nameIsNotUnique || emailIsNotUnique)
		{
			return;
		}

		var addRequest = new AddUserCommandRequest(
			_adminOptions.Name,
			_adminOptions.Email,
			_adminOptions.Password,
			_adminOptions.Password,
			_adminOptions.FirstName,
			_adminOptions.LastName);

		var response = await _sender.SendAsync(addRequest, cancellationToken);

		var addClaimRequest = new AddUserClaimCommandRequest(response.Response.Id, ApplicationClaims.Admin);

		await _sender.SendAsync(addClaimRequest, cancellationToken);
	}
}
