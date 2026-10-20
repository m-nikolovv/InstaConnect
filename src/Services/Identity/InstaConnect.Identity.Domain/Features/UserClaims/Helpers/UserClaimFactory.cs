namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

internal class UserClaimFactory : IUserClaimFactory
{
	private readonly IDateTimeProvider _dateTimeProvider;

	public UserClaimFactory(IDateTimeProvider dateTimeProvider)
	{
		_dateTimeProvider = dateTimeProvider;
	}

	public UserClaim Create(UserId id, ApplicationClaims claim)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var userClaim = new UserClaim(
			new(id, claim),
			utcNow);

		return userClaim;
	}
}
