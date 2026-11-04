using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserCollectionInitializer : MongoDbCollectionInitializer<User>
{
	private readonly AdminOptions _adminOptions;
	private readonly IApplicationSender _sender;
	private readonly IUserCommandRepository _repository;

	public UserCollectionInitializer(
		IMongoCollection<User> collection,
		IOptions<AdminOptions> adminOptions,
		IApplicationSender sender,
		IUserCommandRepository repository)
		: base(
			collection,
			[
				new(Builders<User>.IndexKeys.Ascending(c => c.Id.Id)),
				new(Builders<User>.IndexKeys.Ascending(c => c.Name.Value)),
				new(Builders<User>.IndexKeys.Ascending(c => c.Email.Value))
			])
	{
		_adminOptions = adminOptions.Value;
		_sender = sender;
		_repository = repository;
	}

	public override async Task SeedAsync(CancellationToken cancellationToken)
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
