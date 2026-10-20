using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeValidationExceptionAssertions
{
	extension(PostLikeController controller)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			AddPostLikeApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			DeletePostLikeApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			GetPostLikeByIdApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			GetAllPostLikesApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			AddPostLikeApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.UserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			DeletePostLikeApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.UserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			GetPostLikeByIdApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.UserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			GetPostLikeByIdApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.CurrentUserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			GetAllPostLikesApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.CurrentUserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserNameAsync(
			GetAllPostLikesApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.UserName,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			GetAllPostLikesApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.SortOrder,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
			GetAllPostLikesApiRequest request,
			IEnumMessageTransformer<PostLikesSortTerm> messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.SortTerm,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
			GetAllPostLikesApiRequest request,
			IIntMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Page,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			GetAllPostLikesApiRequest request,
			IIntMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.PageSize,
				messageTransformer,
				cancellationToken);
		}
	}

	extension(UserPostLikeController controller)
	{
		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			GetAllPostLikesForUserApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.UserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			GetAllPostLikesForUserApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.CurrentUserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			GetAllPostLikesForUserApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.SortOrder,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForSortTermAsync(
			GetAllPostLikesForUserApiRequest request,
			IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.SortTerm,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageAsync(
			GetAllPostLikesForUserApiRequest request,
			IIntMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Page,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			GetAllPostLikesForUserApiRequest request,
			IIntMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetAllAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.PageSize,
				messageTransformer,
				cancellationToken);
		}
	}
}
