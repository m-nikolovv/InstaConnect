using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;

public static class PostImageMockAssertions
{
	extension(IPostImageCollection collection)
	{
		public void ShouldHaveReceivedOneAggregateFluent(PostImageId id)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent(ICollection<PostImageId> ids)
		{
			collection.ShouldHaveReceivedOneAggregateFluent();
		}

		public void ShouldHaveReceivedOneAggregateFluent()
		{
			collection.ShouldHaveReceivedOne().AggregateFluent();
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteAsync(postImage, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			ICollection<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			await collection.ShouldHaveReceivedOne().DeleteRangeAsync(postImages, cancellationToken);
		}
	}

	extension(IPostImageFluent fluent)
	{
		public void ShouldHaveReceivedOneMatch(PostImageId id)
		{
			fluent.ShouldHaveReceivedOne().Match(id);
		}

		public void ShouldHaveReceivedOneMatch(ICollection<PostImageId> ids)
		{
			fluent.ShouldHaveReceivedOne().Match(ids);
		}

		public async Task ShouldHaveReceivedOneFirstOrDefaultAsync(
			PostImageId id,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(cancellationToken);
		}

		public async Task ShouldHaveReceivedOneToListAsync(
			ICollection<PostImageId> ids,
			CancellationToken cancellationToken)
		{
			await fluent.ShouldHaveReceivedOneToListAsync(cancellationToken);
		}
	}
}
