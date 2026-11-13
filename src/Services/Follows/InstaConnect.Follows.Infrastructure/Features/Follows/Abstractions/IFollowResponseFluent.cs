namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowResponseFluent : IMongoDbResponseFluent<FollowResponse>
{
	public IFollowResponseFluent Sort(FollowsSortingQuery query);
	public IFollowResponseFluent Sort(FollowsForFollowingSortingQuery query);
	public IFollowResponseFluent Paginate(FollowsPaginationQuery query);
}
