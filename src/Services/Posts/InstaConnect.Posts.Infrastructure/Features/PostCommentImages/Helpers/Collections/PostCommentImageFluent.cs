using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

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
