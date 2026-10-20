using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetAllPostsApiRequest(
	[UserIdFromClaim] string CurrentUserId,
	[FromQuery] string UserName = UserDefaultValues.Name,
	[FromQuery] string Title = PostDefaultValues.Title,
	[FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
	[FromQuery] PostsSortTerm SortTerm = PostDefaultValues.SortTerm,
	[FromQuery] int Page = PostDefaultValues.Page,
	[FromQuery] int PageSize = PostDefaultValues.PageSize) : ISortableApiRequest<PostsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
