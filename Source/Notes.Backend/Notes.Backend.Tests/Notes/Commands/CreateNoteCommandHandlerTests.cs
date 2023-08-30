using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Notes.Commands.CreateNote;
using Notes.Backend.Tests.Common;

namespace Notes.Backend.Tests.Notes.Commands
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateNoteCommandHandler(_context);
            string noteName = "note name";
            string noteText = "note text";

            // Act
            var notedId = await handler.Handle(
                new CreateNoteCommand
                {
                    UserId = NotesContextFactory.UserIdA,
                    Name = noteName,
                    Text = noteText
                },
                CancellationToken.None
                );

            // Assert
            Assert.NotNull(
                await _context.Notes.SingleOrDefaultAsync(note =>
                    note.Id == notedId && note.Name == noteName &&
                    noteText == note.Text));
        }
    }
}
