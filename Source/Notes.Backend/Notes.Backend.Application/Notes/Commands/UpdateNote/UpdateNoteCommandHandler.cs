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

        public async Task<Guid> ExecuteAsync(UpdateNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == command.Id, cancellationToken);

            entity.Name = command.Name;
            entity.Text = command.Text;
            entity.UpdateDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
