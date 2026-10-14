namespace InstaConnect.Posts.Domain.Features.PostImages.Helpers;

internal class PostImageFactory : IPostImageFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;

	public PostImageFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
	}

	public ICollection<PostImage> CreateRange(PostId id, IEnumerable<Image> images)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var postImages = images
			.Select(image => new PostImage(
				new(id, _guidProvider.NewStringGuid()),
				image,
				utcNow))
			.ToList();

		return postImages;
	}
}
