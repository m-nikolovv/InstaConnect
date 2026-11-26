namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class GetPostByIdQueryBuilderFactory
{
	public GetPostByIdQueryBuilder Create(Post post)
	{
		return new(post);
	}
}
