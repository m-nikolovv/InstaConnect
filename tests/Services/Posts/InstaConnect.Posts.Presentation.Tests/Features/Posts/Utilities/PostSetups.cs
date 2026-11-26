using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.Features.Posts.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public PostController GetPostController()
		{
			return serviceProvider.GetRequiredService<PostController>();
		}

		public UserPostController GetUserPostController()
		{
			return serviceProvider.GetRequiredService<UserPostController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public PostController GetPostController()
		{
			return serviceScope.ServiceProvider.GetPostController();
		}

		public UserPostController GetUserPostController()
		{
			return serviceScope.ServiceProvider.GetUserPostController();
		}

		internal async Task<Post?> GetByIdAsync(
		PostIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostId(id.Id),
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			AddPostApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			UpdatePostApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			ActionResult<AddPostApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<Post?> GetByIdAsync(
			ActionResult<UpdatePostApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddPostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(post, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(post, request.UserId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeletePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(post, request.UserId, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostByIdApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(post, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostsApiRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(posts, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostsForUserApiRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(posts, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(post, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(post, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(post, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostByIdApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(post, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostsApiRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(posts, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostsForUserApiRequest request,
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(posts, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			UpdatePostApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			GetPostByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.CurrentUserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			UpdatePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}
	}
}
