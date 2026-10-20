namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

public interface IPostResponseFluentFactory
{
	public IPostResponseFluent Create(IAggregateFluent<PostResponse> fluent);
}
