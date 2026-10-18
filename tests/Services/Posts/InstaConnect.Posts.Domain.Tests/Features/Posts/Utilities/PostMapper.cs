using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostMapper
{
	extension(User user)
	{
		public UserResponse ToResponse(
			GetAllPostsForUserQuery query)
		{
			return user.ToFullResponse();
		}
	}

	extension(Post post)
	{
		internal PostResponse ToFullResponse<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.User?.ToFullResponse(),
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		internal PostResponse ToResponseWithoutUser<TQuery>(
			TQuery request)
			where TQuery : ICurrentUserableQuery
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   null,
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(request.CurrentUser.Id)),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public Post To(AddPostCommand command)
		{
			return new(post.Id,
					   command.Title,
					   command.Content,
					   command.UserId,
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}

		public PostId ToResponse(
			AddPostCommand command)
		{
			return post.ToId();
		}

		public PostId ToResponse(
			UpdatePostCommand command)
		{
			return post.ToId();
		}

		public PostResponse ToResponse(
			GetPostByIdQuery query)
		{
			return post.ToFullResponse(query);
		}

		public PostAnalyzeResponse ToResponse(
			AnalyzePostByIdQuery query)
		{
			return new(post.Id,
					   post.UserId,
					   post.Title,
					   post.Content,
					   post.User?.ToFullResponse(),
					   post.PostImages.ToFullResponse(),
					   post.PostLikes.Any(pl => pl.Id.UserId.Matches(query.CurrentUser.Id)),
					   post.GetAnalysisSummary(),
					   post.CreatedAtUtc,
					   post.UpdatedAtUtc);
		}
	}

	extension(ICollection<Post> posts)
	{
		public ICollection<PostResponse> ToResponse(
			GetAllPostsQuery query)
		{
			return posts.Filter(query.Pagination, post => post.MatchesFilter(query.Filter), post => post.ToFullResponse(query));
		}

		public ICollection<PostResponse> ToResponse(
			GetAllPostsForUserQuery query)
		{
			return posts.Filter(query.Pagination, post => post.MatchesFilter(query.Filter), post => post.ToResponseWithoutUser(query));
		}

		public long ToTotalCountResponse(
			GetAllPostsQuery query)
		{
			return posts.Count(post => post.MatchesFilter(query.Filter));
		}

		public long ToTotalCountResponse(
			GetAllPostsForUserQuery query)
		{
			return posts.Count(post => post.MatchesFilter(query.Filter));
		}
	}

	extension(ICollection<PostImage> postImages)
	{
		public ICollection<PostImage> To(AddPostCommand command)
		{
			return [.. postImages.Zip(command.Images, (postImage, formFile) => new PostImage(
				postImage.Id,
				new(formFile.GetUrl()),
				postImage.CreatedAtUtc))];
		}
	}
}
