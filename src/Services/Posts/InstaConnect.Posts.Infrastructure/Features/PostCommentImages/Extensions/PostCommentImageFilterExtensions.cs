using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Extensions;

internal static class PostCommentImageFilterExtensions
{
	extension(PostCommentImageId filter)
	{
		public FilterDefinition<PostCommentImage> GetFilter()
		{
			return filter.GetFilterForIdEquals<PostCommentImage>(p => p.Id.Id.Id.Id, p => p.Id.Id.CommentId, p => p.Id.ImageId);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> commentIdField,
			Expression<Func<T, object>> imageIdField)
		{
			var id = filter.Id.GetFilterForIdEquals(idField, commentIdField);
			var imageId = Builders<T>.Filter.EqualsIgnoreCase(
				imageIdField, filter.ImageId, filter.ImageId.IsNullOrEmptyOrWhiteSpace());

			return Builders<T>.Filter.And(id, imageId);
		}
	}

	extension(IEnumerable<PostCommentImageId> filter)
	{
		public FilterDefinition<PostCommentImage> GetFilter()
		{
			return filter.GetFilterForIdRange<PostCommentImage>(p => p.Id.Id.Id.Id, p => p.Id.Id.CommentId, p => p.Id.ImageId);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> commentIdField,
			Expression<Func<T, object>> imageIdField)
		{
			return Builders<T>.Filter.Or(filter.Select(item => item.GetFilterForIdEquals(idField, commentIdField, imageIdField)));
		}
	}
}
