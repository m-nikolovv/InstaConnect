namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentResponseFluentFactory
{
	public IPostCommentResponseFluent Create(IAggregateFluent<PostCommentResponse> fluent);
}
