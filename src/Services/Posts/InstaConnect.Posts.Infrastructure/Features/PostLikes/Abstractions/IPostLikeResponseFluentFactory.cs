namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeResponseFluentFactory
{
	public IPostLikeResponseFluent Create(IAggregateFluent<PostLikeResponse> fluent);
}
