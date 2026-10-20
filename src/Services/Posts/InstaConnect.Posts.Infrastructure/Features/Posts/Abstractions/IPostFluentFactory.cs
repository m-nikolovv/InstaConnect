namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostFluentFactory
{
	public IPostFluent Create(IAggregateFluent<Post> fluent);
}
