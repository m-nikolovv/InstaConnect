namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class PostFactory : IPostFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;

	public PostFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
	}

	public Post Create(UserId userId, string title, string content)
	{
		var id = _guidProvider.NewStringGuid();
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var post = new Post(
			new(id),
			title,
			content,
			new(string.Empty),
			userId,
			utcNow,
			utcNow);

		return post;
	}
}
