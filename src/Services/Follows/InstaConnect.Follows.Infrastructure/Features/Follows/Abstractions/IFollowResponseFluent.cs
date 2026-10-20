namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowResponseFluent : IMongoDbResponseFluent<FollowResponse>
{
	public IFollowResponseFluent ApplySorting(FollowsSortingQuery query);
	public IFollowResponseFluent ApplySorting(FollowsForFollowingSortingQuery query);
	public IFollowResponseFluent ApplyPagination(FollowsPaginationQuery query);
}
