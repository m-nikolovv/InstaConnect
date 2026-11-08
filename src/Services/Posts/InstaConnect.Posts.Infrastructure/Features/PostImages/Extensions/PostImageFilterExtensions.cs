using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

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
			var imageId = Builders<T>.Filter.EqualsIgnoreCaseOrFalse(imageIdField, filter.ImageId);

			return Builders<T>.Filter.AndAll(id, imageId);
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
			return Builders<T>.Filter.OrRange(filter.Select(item => item.GetFilterForIdEquals(idField, imageIdField)));
		}
	}

	extension(IEnumerable<PostId> filter)
	{
		public FilterDefinition<PostImage> GetPostImageCascadeFilter()
		{
			return filter.GetFilterForIdRange<PostImage>(p => p.Id.Id.Id);
		}
	}
}
