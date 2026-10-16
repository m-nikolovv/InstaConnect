using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Includers;

internal class PostPostImagesIncluder : IPostLikeIncluder
{
	private readonly IMongoCollection<PostImage> _collection;

	public PostPostImagesIncluder(IMongoCollection<PostImage> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostImage;

	public IAggregateFluent<PostLike> Include(IAggregateFluent<PostLike> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.Post!.Id,
				i => i.Id.Id,
				p => p.Post!.PostImages
			);
	}
}
