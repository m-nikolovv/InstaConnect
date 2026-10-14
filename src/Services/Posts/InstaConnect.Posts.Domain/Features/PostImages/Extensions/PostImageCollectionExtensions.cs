namespace InstaConnect.Posts.Domain.Features.PostImages.Extensions;

public static class PostImageCollectionExtensions
{
	extension(ICollection<PostImage> postImages)
	{
		public ICollection<PostImage> AddPost(Post post)
		{
			foreach (var postImage in postImages)
			{
				postImage.AddPost(post);
			}

			return postImages;
		}
	}
}
