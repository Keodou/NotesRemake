using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Interfaces;

namespace Notes.Backend.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Executes a request to update the data
        /// </summary>
        /// <param name="command">Request to be executed</param>
        /// <param name="cancellationToken">Token to cancel the operation</param>
        /// <returns>ID of the updated object</returns>
        public async Task<Guid> ExecuteAsync(UpdateNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == command.Id, cancellationToken);

            if (entity != null)
            {
                entity.Name = command.Name;
                entity.Text = command.Text;
                entity.UpdateDate = DateTime.Now;

                await _dbContext.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }

            return Guid.Empty;
        }
    }
}
