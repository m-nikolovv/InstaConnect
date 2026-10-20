namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

public class UserClaim : IEntityWithId<UserClaimId>
{
	public UserClaim()
	{
		Id = new(new(string.Empty), ApplicationClaims.None);
	}

	public UserClaim(UserClaimId id, DateTimeOffset createdAtUtc)
	{
		Id = id;
		CreatedAtUtc = createdAtUtc;
	}

	public UserClaimId Id { get; }

	public DateTimeOffset CreatedAtUtc { get; }

	public User? User { get; private set; }

	public UserClaim AddUser(User? user)
	{
		User = user;

		return this;
	}
}
