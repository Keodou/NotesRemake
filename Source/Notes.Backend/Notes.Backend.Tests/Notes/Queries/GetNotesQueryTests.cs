using Notes.Backend.Application.Notes.Queries.GetNotes;
using Notes.Backend.Tests.Common;

namespace Notes.Backend.Tests.Notes.Queries
{
    public class GetNotesQueryTests : TestCommandBase
    {
        [Fact]
        public async Task GetNotesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNotesQueryHandler(_context);

            // Act
            var result = await handler.Handle(
                new GetNotesQuery
                {
                    UserId = NotesContextFactory.UserIdB
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }
    }
}
