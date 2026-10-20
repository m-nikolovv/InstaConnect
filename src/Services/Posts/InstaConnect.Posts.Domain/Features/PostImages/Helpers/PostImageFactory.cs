using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;

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

	public ICollection<PostImage> CreateRange(PostId id, ICollection<Url> urls)
	{
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var postImages = urls
			.Select(url => new PostImage(
				new(id, _guidProvider.NewStringGuid()),
				url,
				utcNow))
			.ToList();

		return postImages;
	}
}
