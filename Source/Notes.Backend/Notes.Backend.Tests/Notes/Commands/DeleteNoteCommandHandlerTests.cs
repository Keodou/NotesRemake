using Notes.Backend.Application.Notes.Commands.DeleteNote;
using Notes.Backend.Tests.Common;

namespace Notes.Backend.Tests.Notes.Commands
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(_context);

            // Act
            await handler.Handle(new DeleteNoteCommand
            {
                NoteId = NotesContextFactory.NoteIdForDelete
            }, CancellationToken.None);

            // Assert
            Assert.Null(_context.Notes.SingleOrDefault(note =>
                note.Id == NotesContextFactory.NoteIdForDelete));
        }
    }
}
