using System.Linq.Expressions;

using InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Extensions;

internal static class PostImageFilterExtensions
{
	extension(PostImageId filter)
	{
		public FilterDefinition<PostImage> GetFilter()
		{
			return filter.GetFilterForIdEquals<PostImage>(p => p.Id.Id.Id, p => p.Id.ImageId);
		}

		public FilterDefinition<T> GetFilterForIdEquals<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> imageIdField)
		{
			var id = filter.Id.GetFilterForIdEquals(idField);
			var imageId = Builders<T>.Filter.EqualsIgnoreCase(
				imageIdField, filter.ImageId, filter.ImageId.IsNullOrEmptyOrWhiteSpace());

			return Builders<T>.Filter.And(id, imageId);
		}
	}

	extension(IEnumerable<PostImageId> filter)
	{
		public FilterDefinition<PostImage> GetFilter()
		{
			return filter.GetFilterForIdRange<PostImage>(p => p.Id.Id.Id, p => p.Id.ImageId);
		}

		public FilterDefinition<T> GetFilterForIdRange<T>(
			Expression<Func<T, object>> idField,
			Expression<Func<T, object>> imageIdField)
		{
			return Builders<T>.Filter.Or(filter.Select(item => item.GetFilterForIdEquals(idField, imageIdField)));
		}
	}
}
