namespace InstaConnect.Common.Presentation.Features.Exceptions.Abstractions;

public interface IApplicationProblemDetailsFactory
{
	public ApplicationProblemDetails Create(Exception exception);

	public ApplicationProblemDetails Create(BaseException exception);

	public ApplicationProblemDetails Create(InvalidValidationException exception);

}
