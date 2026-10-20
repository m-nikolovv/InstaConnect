namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimFluent : IMongoDbFluent<UserClaim>
{
	public IUserClaimFluent Match(UserClaimsFilterQuery filter);
	public IUserClaimFluent Match(UserClaimId filter);
	public IUserClaimResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IUserClaimResponseFluent ProjectToResponseWithoutUser(CurrentUserQuery currentUser);
	public IUserClaimFluent ApplyIncludes(UserClaimInclude include);
}
