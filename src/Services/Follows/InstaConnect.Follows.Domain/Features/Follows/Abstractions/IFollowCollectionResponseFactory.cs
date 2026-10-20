namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowCollectionResponseFactory
{
	public FollowCollectionResponse Create(UserResponse follower, ICollection<FollowResponse> follows, long totalCount, FollowsPaginationQuery pagination);

	public FollowCollectionResponse CreateForFollowing(UserResponse following, ICollection<FollowResponse> follows, long totalCount, FollowsPaginationQuery pagination);
}
