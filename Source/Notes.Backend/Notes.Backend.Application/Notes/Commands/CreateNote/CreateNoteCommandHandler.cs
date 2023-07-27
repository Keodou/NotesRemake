using MediatR;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Executes a request to create the data.
        /// </summary>
        /// <param name="command">Request to be executed.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>ID of the created object.</returns>
        public async Task<Guid> Handle(CreateNoteCommand command, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
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
