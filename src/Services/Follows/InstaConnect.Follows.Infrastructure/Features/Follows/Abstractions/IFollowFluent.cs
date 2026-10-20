namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowFluent : IMongoDbFluent<Follow>
{
	public IFollowFluent Match(FollowsFilterQuery filter);
	public IFollowFluent Match(FollowsForFollowingFilterQuery filter);
	public IFollowFluent Match(FollowId filter);
	public IFollowResponseFluent ProjectToFullResponse(CurrentUserQuery currentUser);
	public IFollowResponseFluent ProjectToResponseWithoutFollower(CurrentUserQuery currentUser);
	public IFollowResponseFluent ProjectToResponseWithoutFollowing(CurrentUserQuery currentUser);
	public IFollowFluent ApplyIncludes(FollowInclude include);
}
