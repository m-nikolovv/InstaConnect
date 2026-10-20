using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageMockSetups
{
	extension(IPostCommentImageCollection collection)
	{
		public void SetupAggregateFluent(
			PostCommentImageId id,
			IPostCommentImageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(
			ICollection<PostCommentImageId> ids,
			IPostCommentImageFluent fluent)
		{
			collection.SetupAggregateFluent(fluent);
		}

		public void SetupAggregateFluent(IPostCommentImageFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostCommentImageFluent fluent)
	{
		public void SetupMatch(PostCommentImageId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(ICollection<PostCommentImageId> ids)
		{
			fluent.Match(ids).ReturnsResponse(fluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentImageId id,
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			fluent.SetupFirstOrDefaultAsync(postCommentImage, cancellationToken);
		}

		public void SetupToListAsync(
			ICollection<PostCommentImageId> ids,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			fluent.SetupToListAsync(postCommentImages, cancellationToken);
		}
	}
}
