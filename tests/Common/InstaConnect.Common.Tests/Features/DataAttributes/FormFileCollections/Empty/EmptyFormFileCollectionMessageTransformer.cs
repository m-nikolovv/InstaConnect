using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Empty;

internal class EmptyFormFileCollectionMessageTransformer : IFormFileCollectionMessageTransformer
{
	public string Transform<T>(Expression<Func<T, ICollection<IFormFile>>> propertyExpression, ICollection<IFormFile> value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
