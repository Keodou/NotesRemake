using Microsoft.EntityFrameworkCore;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Persistence
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext()
        {

        }

        //public DbSet<Note> Notes { get; set; }
        public List<Note> Notes
        {
            get
            {
                return new List<Note>
                {
                    new Note() { Id =  Guid.NewGuid(), Name = "Новая заметка", CreateDate = DateTime.Now, Text = "Новая заметка текст", UpdateDate = DateTime.Now },
                    new Note() { Id =  Guid.NewGuid(), Name = "Вторая заметка", CreateDate = DateTime.Now, Text = "Вторая заметка текст", UpdateDate = DateTime.Now },
                };
            }
        }
    }
}
