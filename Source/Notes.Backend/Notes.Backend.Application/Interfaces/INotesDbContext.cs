using Microsoft.EntityFrameworkCore;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
