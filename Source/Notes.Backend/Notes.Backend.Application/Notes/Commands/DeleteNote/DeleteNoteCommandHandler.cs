using Notes.Backend.Application.Interfaces;

namespace Notes.Backend.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler
    {
        private readonly INotesDbContext _dbContext;

        public DeleteNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> ExecuteAsync(DeleteNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FindAsync(new object[] { command.NoteId }, cancellationToken);
            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
