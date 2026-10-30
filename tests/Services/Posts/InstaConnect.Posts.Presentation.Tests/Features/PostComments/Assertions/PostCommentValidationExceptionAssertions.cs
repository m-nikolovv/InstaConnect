using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;
using InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationExceptionAssertions
{
	extension(PostCommentController controller)
	{
		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			AddPostCommentApiRequest request,
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
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Id,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForIdAsync(
			DeletePostCommentApiRequest request,
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
			GetPostCommentByIdApiRequest request,
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
			GetAllPostCommentsApiRequest request,
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

		public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.CommentId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
			DeletePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.DeleteAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.CommentId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCommentIdAsync(
			GetPostCommentByIdApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.GetByIdAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.CommentId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			AddPostCommentApiRequest request,
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
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.UserId,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			DeletePostCommentApiRequest request,
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

		public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
			AddPostCommentApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Form.Content,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForContentAsync(
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.UpdateAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Body.Content,
				messageTransformer,
				cancellationToken);
		}

		public async Task ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			GetPostCommentByIdApiRequest request,
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
			GetAllPostCommentsApiRequest request,
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
			GetAllPostCommentsApiRequest request,
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
			GetAllPostCommentsApiRequest request,
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
			GetAllPostCommentsApiRequest request,
			IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer,
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
			GetAllPostCommentsApiRequest request,
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
			GetAllPostCommentsApiRequest request,
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

		public async Task ShouldThrowInvalidValidationExceptionForImagesAsync(
			AddPostCommentApiRequest request,
			IFormFileCollectionMessageTransformer messageTransformer,
			CancellationToken cancellationToken)
		{
			var func = () => controller.AddAsync(request, cancellationToken);

			await func.ShouldThrowInvalidValidationExceptionAsync(
				request,
				r => r.Form.Images,
				messageTransformer,
				cancellationToken);
		}
	}

	extension(UserPostCommentController controller)
	{
		public async Task ShouldThrowInvalidValidationExceptionForUserIdAsync(
			GetAllPostCommentsForUserApiRequest request,
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
			GetAllPostCommentsForUserApiRequest request,
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
			GetAllPostCommentsForUserApiRequest request,
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
			GetAllPostCommentsForUserApiRequest request,
			IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer,
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
			GetAllPostCommentsForUserApiRequest request,
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
			GetAllPostCommentsForUserApiRequest request,
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
