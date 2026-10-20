using InstaConnect.Posts.Domain.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Domain.Features.PostComments.Extensions;
using InstaConnect.Posts.Domain.Features.PostLikes.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Extensions;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetPosts()
		{
			user?.Posts.AddUser(user);

			return user;
		}

		public User? SetPostLikes()
		{
			user?.PostLikes.AddUser(user).SetPost();

			return user;
		}

		public User? SetPostComments()
		{
			user?.PostComments.AddUser(user).SetPost();

			return user;
		}

		public User? SetPostCommentLikes()
		{
			user?.PostCommentLikes.AddUser(user).SetPostComment();

			return user;
		}
	}
}
