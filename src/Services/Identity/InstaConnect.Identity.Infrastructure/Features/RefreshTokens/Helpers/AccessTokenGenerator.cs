using System.Security.Claims;

using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Domain.Features.AccessTokens.Utilities;
using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers;

internal class AccessTokenGenerator : IAccessTokenGenerator
{
	private readonly IBaseAccessTokenGenerator _baseAccessTokenGenerator;

	public AccessTokenGenerator(IBaseAccessTokenGenerator baseAccessTokenGenerator)
	{
		_baseAccessTokenGenerator = baseAccessTokenGenerator;
	}

	public AccessToken Generate(User user)
	{
		return _baseAccessTokenGenerator.Generate(
			[new(DefaultClaims.Id, user.Id.Id),
			 new(DefaultClaims.Email, user.Email.Value),
			 new(DefaultClaims.FirstName, user.FirstName),
			 new(DefaultClaims.LastName, user.LastName),
			 new(DefaultClaims.Name, user.Name.Value),
			 ..user.UserClaims.Select(uc => new Claim(uc.Id.Claim.GetName(), uc.Id.Claim.GetName()))]);
	}
}
