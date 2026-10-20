namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Assertions;

public static class PostLikeValidationAssertions
{
	extension(TestValidationResult<DeletePostLikeCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			DeletePostLikeCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(
			DeletePostLikeCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetPostLikeByIdQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			GetPostLikeByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(
			GetPostLikeByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetPostLikeByIdQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}
	}

	extension(TestValidationResult<AddPostLikeCommandRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			AddPostLikeCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserId(
			AddPostLikeCommandRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostLikesQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForId(
			GetAllPostLikesQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Id, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllPostLikesQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForUserName(
			GetAllPostLikesQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.UserName, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllPostLikesQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllPostLikesQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllPostLikesQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllPostLikesQueryRequest request,
			IEnumMessageTransformer<PostLikesSortTerm> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}

	extension(TestValidationResult<GetAllPostLikesForUserQueryRequest> response)
	{
		public void ShouldHaveValidationErrorForUserId(
			GetAllPostLikesForUserQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.UserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForCurrentUserId(
			GetAllPostLikesForUserQueryRequest request,
			IStringMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.CurrentUserId, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPage(
			GetAllPostLikesForUserQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.Page, messageTransformer);
		}

		public void ShouldHaveValidationErrorForPageSize(
			GetAllPostLikesForUserQueryRequest request,
			IIntMessageTransformer messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.PageSize, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortOrder(
			GetAllPostLikesForUserQueryRequest request,
			IEnumMessageTransformer<CommonSortOrder> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortOrder, messageTransformer);
		}

		public void ShouldHaveValidationErrorForSortTerm(
			GetAllPostLikesForUserQueryRequest request,
			IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer)
		{
			response.ShouldHaveValidationErrorForProperty(request, p => p.SortTerm, messageTransformer);
		}
	}
}
