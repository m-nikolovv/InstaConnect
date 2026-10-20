namespace InstaConnect.Chats.Tests.Features.ChatMessages.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class ChatMessagesSortOrderEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<CommonSortOrder>;
