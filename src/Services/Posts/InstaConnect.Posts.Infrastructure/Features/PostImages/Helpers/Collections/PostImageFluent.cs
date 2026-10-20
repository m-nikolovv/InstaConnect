using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Collections;

internal class PostImageFluent : MongoDbFluent<PostImage>, IPostImageFluent
{
	public PostImageFluent(IAggregateFluent<PostImage> fluent) : base(fluent)
	{
	}

	public IPostImageFluent Match(PostImageId filter)
	{
		Match(filter.GetFilter());

		return this;
	}

	public IPostImageFluent Match(IEnumerable<PostImageId> filter)
	{
		Match(filter.GetFilter());

		return this;
	}
}
