namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

public interface IPostLikeFluentFactory
{
	public IPostLikeFluent Create(IAggregateFluent<PostLike> fluent);
}
