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

        /// <summary>
        /// Executes a request to delete the data.
        /// </summary>
        /// <param name="command">Request to be executed.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>ID of the deleted object.</returns>
        public async Task<Guid> ExecuteAsync(DeleteNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FindAsync(new object[] { command.NoteId }, cancellationToken);

            if (entity != null)
            {
                _dbContext.Notes.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }

            return Guid.Empty;
        }
    }
}
