using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Common.Exceptions;
using Notes.Backend.Application.Notes.Commands.UpdateNote;
using Notes.Backend.Tests.Common;

namespace Notes.Backend.Tests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(_context);
            string updateName = "Title1";

            // Act
            await handler.Handle(new UpdateNoteCommand
            {
                Id = NotesContextFactory.NoteIdForUpdate,
                UserId = NotesContextFactory.UserIdB,
                Name = updateName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await _context.Notes.SingleOrDefaultAsync(note =>
                note.Id == NotesContextFactory.NoteIdForUpdate &&
                note.Name == updateName));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateNoteCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = NotesContextFactory.UserIdA
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateNoteCommand
                    {
                        Id = NotesContextFactory.NoteIdForUpdate,
                        UserId = NotesContextFactory.UserIdA
                    },
                    CancellationToken.None));
        }
    }
}
