using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Includers;

internal class PostCommentPostCommentImagesIncluder : IPostCommentLikeIncluder
{
	private readonly IMongoCollection<PostCommentImage> _collection;

	public PostCommentPostCommentImagesIncluder(IMongoCollection<PostCommentImage> collection)
	{
		_collection = collection;
	}

	public PostsDestinationType DestinationType => PostsDestinationType.PostComment;

	public PostsIncludeType IncludeType => PostsIncludeType.PostCommentImage;

	public IAggregateFluent<PostCommentLike> Include(IAggregateFluent<PostCommentLike> aggregate)
	{
		return aggregate
			.IncludeMany(
				_collection,
				p => p.PostComment!.Id,
				i => i.Id.Id,
				p => p.PostComment!.PostCommentImages
			);
	}
}
