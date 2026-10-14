using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.Base;

public interface IFormFileCollectionMessageTransformer : IMessageTransformer<ICollection<IFormFile>>;
