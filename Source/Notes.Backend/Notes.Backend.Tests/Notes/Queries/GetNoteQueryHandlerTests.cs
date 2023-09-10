using Notes.Backend.Application.Notes.Queries.GetNote;
using Notes.Backend.Tests.Common;

namespace Notes.Backend.Tests.Notes.Queries
{
    public class GetNoteQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetNoteQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteQueryHandler(_context);

            // Act
            var result = await handler.Handle(
                new GetNoteQuery
                {
                    NoteId = NotesContextFactory.NoteIdForUpdate
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }
    }
}
