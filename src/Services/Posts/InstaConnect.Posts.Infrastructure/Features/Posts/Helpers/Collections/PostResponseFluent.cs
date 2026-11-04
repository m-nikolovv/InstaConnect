namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluent :
	MongoDbResponseFluent<PostResponse>, IPostResponseFluent
{
	public PostResponseFluent(IAggregateFluent<PostResponse> fluent) : base(fluent)
	{
	}
}
