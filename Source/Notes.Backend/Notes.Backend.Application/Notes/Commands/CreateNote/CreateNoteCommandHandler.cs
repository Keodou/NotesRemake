using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler
    {
        private INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> ExecuteAsync(CreateNoteCommand command, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Name = command.Name,
                Text = command.Text,
                CreateDate = DateTime.Now,
                UpdateDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
