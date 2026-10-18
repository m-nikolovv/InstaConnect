namespace InstaConnect.Posts.Domain.Features.PostCommentImages.Helpers;

internal class PostCommentImageFactory : IPostCommentImageFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;

	public PostCommentImageFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
	}

	public ICollection<PostCommentImage> CreateRange(PostCommentId id, ICollection<Url> urls)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var postCommentImages = urls
			.Select(url => new PostCommentImage(
				new(id, _guidProvider.NewStringGuid()),
				url,
				utcNow))
			.ToList();

		return postCommentImages;
	}
}
