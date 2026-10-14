using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Includers;

internal class PostImagesIncluder : IPostIncluder
{
	private readonly IMongoCollection<PostImage> _collection;

	public PostImagesIncluder(IMongoCollection<PostImage> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostImage;

	public IAggregateFluent<Post> Include(IAggregateFluent<Post> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Id,
				i => i.Id.Id,
				p => p.PostImages
			);
	}
}
