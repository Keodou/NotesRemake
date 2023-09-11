using Notes.Backend.Application.Common.Exceptions;
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
                    // TODO: remake value
                    NoteId = NotesContextFactory.NoteIdForGet
                }, 
                CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetNoteQueryHandler_WrongId()
        {
            // Arrange
            var handler = new GetNoteQueryHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetNoteQuery
                    {
                        NoteId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
