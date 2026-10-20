using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;

public static class PostCommentImageMockAssertions
{
	extension(IPostCommentImageCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(PostCommentImageId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<PostCommentImageId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(postCommentImage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteRangeAsync(postCommentImages, cancellationToken);
		}
	}

	extension(IPostCommentImageFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(PostCommentImageId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<PostCommentImageId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostCommentImageId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<PostCommentImageId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
