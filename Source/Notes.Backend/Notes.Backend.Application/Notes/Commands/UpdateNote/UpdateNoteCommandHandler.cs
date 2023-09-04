using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Common.Exceptions;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;

namespace Notes.Backend.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Executes a request to update the data.
        /// </summary>
        /// <param name="command">Request to be executed.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>ID of the updated object.</returns>
        public async Task<Guid> Handle(UpdateNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == command.Id
                && note.UserId == command.UserId, cancellationToken);

            if (entity == null || entity.UserId != command.UserId)
            {
                throw new NotFoundException("Note no update found.");
            }

            entity.Name = command.Name;
            entity.Text = command.Text;
            entity.UpdateDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
