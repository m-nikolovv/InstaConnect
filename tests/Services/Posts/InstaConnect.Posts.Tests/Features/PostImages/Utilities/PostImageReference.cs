using InstaConnect.Posts.Domain.Features.PostImages.Extensions;

namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageReference
{
	extension(Post? post)
	{
		public Post? SetPostImages()
		{
			post?.PostImages.AddPost(post);

			return post;
		}
	}
}
