namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Assertions;

public static class PostLikeValidationProblemDetailsAssertions
{
	extension(ApplicationProblemDetails problemDetails)
	{
		public void ShouldSatisfyInvalidValidationForId(
		DeletePostLikeApiRequest request,
		IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			GetPostLikeByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			AddPostLikeApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForId(
			GetAllPostLikesApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Id,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetPostLikeByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllPostLikesApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForCurrentUserId(
			GetAllPostLikesForUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.CurrentUserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			GetAllPostLikesForUserApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			GetPostLikeByIdApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			AddPostLikeApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserId(
			DeletePostLikeApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserId,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForUserName(
			GetAllPostLikesApiRequest request,
			IStringMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.UserName,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllPostLikesApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPage(
			GetAllPostLikesForUserApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.Page,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllPostLikesApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForPageSize(
			GetAllPostLikesForUserApiRequest request,
			IIntMessageTransformer messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.PageSize,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllPostLikesApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortOrder(
			GetAllPostLikesForUserApiRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortOrder,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllPostLikesApiRequest request,
			IEnumMessageTransformer<PostLikesSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}

		public void ShouldSatisfyInvalidValidationForSortTerm(
			GetAllPostLikesForUserApiRequest request,
			IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer)
		{
			problemDetails.ShouldSatisfyInvalidValidation(
				request,
				p => p.SortTerm,
				messageTransformer);
		}
	}
}
