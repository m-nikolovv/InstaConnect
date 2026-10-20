namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimFactory
{
	public UserClaim Create(UserId id, ApplicationClaims claim);
}
