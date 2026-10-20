using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Utilities;

public static class PostImageMockSetups
{
	extension(IPostImageCollection collection)
	{
		public void SetupAggregateFluent(
			PostImageId id,
			IPostImageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<PostImageId> ids,
			IPostImageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IPostImageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostImageFluent fluent)
	{
		public void SetupMatch(PostImageId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<PostImageId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostImageId id,
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postImage, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<PostImageId> ids,
			ICollection<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postImages, cancellationToken);
		}
	}
}
