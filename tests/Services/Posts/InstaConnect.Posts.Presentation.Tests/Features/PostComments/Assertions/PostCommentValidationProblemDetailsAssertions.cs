namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Assertions;

public static class PostCommentValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForId(
		AddPostCommentApiRequest request,
		IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			DeletePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			GetPostCommentByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			GetAllPostCommentsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCommentId(
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CommentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCommentId(
			DeletePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CommentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCommentId(
			GetPostCommentByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CommentId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForContent(
			AddPostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Form.Content,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForContent(
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Body.Content,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetPostCommentByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllPostCommentsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllPostCommentsForUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			GetAllPostCommentsForUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			AddPostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			UpdatePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			DeletePostCommentApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserName(
			GetAllPostCommentsApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllPostCommentsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllPostCommentsForUserApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllPostCommentsApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllPostCommentsForUserApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllPostCommentsApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllPostCommentsForUserApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllPostCommentsApiRequest request,
			IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllPostCommentsForUserApiRequest request,
			IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}
	}
}
