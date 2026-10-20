namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeFluentFactory
{
	public IPostCommentLikeFluent Create(IAggregateFluent<PostCommentLike> fluent);
}
