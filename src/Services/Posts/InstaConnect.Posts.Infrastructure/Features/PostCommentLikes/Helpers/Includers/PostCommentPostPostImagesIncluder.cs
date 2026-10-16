using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostPostImagesIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<PostImage> _collection;

	public PostCommentPostPostImagesIncluder(IMongoCollection<PostImage> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.Post;

	public PostsIncludeType IncludeType => PostsIncludeType.PostImage;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.PostComment!.Post!.Id,
				i => i.Id.Id,
				p => p.PostComment!.Post!.PostImages
			);
	}
}
