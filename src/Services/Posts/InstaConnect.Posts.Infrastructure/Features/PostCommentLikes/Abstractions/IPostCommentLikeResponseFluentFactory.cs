namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeResponseFluentFactory
{
	public IPostCommentLikeResponseFluent Create(IAggregateFluent<PostCommentLikeResponse> fluent);
}
