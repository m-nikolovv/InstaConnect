namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluent :
	MongoDbResponseFluent<PostLikeResponse>, IPostLikeResponseFluent
{
	public PostLikeResponseFluent(IAggregateFluent<PostLikeResponse> fluent) : base(fluent)
	{
	}
}
