using FluentValidation;

using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;
using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Common.Application.Features.Validations.PipelineBehaviors;

internal sealed class ValidationPipelineBehavior<TRequest, TResponse>
	: IPipelineBehavior<TRequest, TResponse>
	where TRequest : IBaseRequest
{
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
	{
		_validators = validators;
	}

	public async Task<TResponse> Handle(
		TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		var errorMessages = await _validators.GetErrorMessagesAsync(request, cancellationToken);

		if (errorMessages.Any())
		{
			throw new InvalidValidationException(errorMessages);
		}

		return await next(cancellationToken);
	}
}
