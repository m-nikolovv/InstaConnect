namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

public interface IPostCommentFluentFactory
{
	public IPostCommentFluent Create(IAggregateFluent<PostComment> fluent);
}
