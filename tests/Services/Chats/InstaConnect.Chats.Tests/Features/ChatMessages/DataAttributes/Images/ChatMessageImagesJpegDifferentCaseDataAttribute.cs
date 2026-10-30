using InstaConnect.Common.Tests.Features.DataAttributes.FormFileCollections.JpegDifferentCase;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.Images;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessageImagesJpegDifferentCaseDataAttribute : JpegDifferentCaseFormFileCollectionDataAttribute
{
}
