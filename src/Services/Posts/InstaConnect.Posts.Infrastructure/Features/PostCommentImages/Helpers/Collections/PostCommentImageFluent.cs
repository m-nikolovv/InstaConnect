using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Collections;

internal class PostCommentImageFluent : MongoDbFluent<PostCommentImage>, IPostCommentImageFluent
{
	public PostCommentImageFluent(IAggregateFluent<PostCommentImage> fluent) : base(fluent)
	{
	}

	public IPostCommentImageFluent Match(PostCommentImageId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostCommentImageFluent Match(IEnumerable<PostCommentImageId> filter)
	{
		Match(filter.GetFilter());

		return this;
	}
}
