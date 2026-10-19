using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimBuilder
{
	private readonly string _id;
	private readonly User _user;
	private readonly ApplicationClaims _claim;
	private readonly DateTimeOffset _createdAtUtc;

	public UserClaimBuilder(User user)
	{
		_id = user.Id.Id;
		_user = user;
		_claim = UserClaimDataFaker.GetClaim();
		_createdAtUtc = UserClaimDataFaker.GetCreatedAtUtc();
	}

	public UserClaimBuilder(UserClaim userClaim)
	{
		_id = userClaim.Id.Id.Id;
		_user = userClaim.User!;
		_claim = userClaim.Id.Claim;
		_createdAtUtc = userClaim.CreatedAtUtc;
	}

	public UserClaim Build()
	{
		var userClaim = new UserClaim(
			new(
				new(_id),
				_claim),
			_createdAtUtc);

		userClaim.AddUser(_user);
		_user.AddUserClaim(userClaim);

		return userClaim;
	}
}
