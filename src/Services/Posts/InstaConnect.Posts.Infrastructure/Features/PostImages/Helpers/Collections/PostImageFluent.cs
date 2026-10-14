using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

using MongoDB.Driver;

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
}
