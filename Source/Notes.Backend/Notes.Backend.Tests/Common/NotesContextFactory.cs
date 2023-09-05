using Microsoft.EntityFrameworkCore;
using Notes.Backend.Domain.Models;
using Notes.Backend.Persistence;

namespace Notes.Backend.Tests.Common
{
    public class NotesContextFactory
    {
        public static Guid UserIdA = Guid.NewGuid();
        public static Guid UserIdB = Guid.NewGuid();

        public static Guid NoteIdForUpdate = Guid.Parse("{3B0A8581-1D22-4EC0-A8FD-DEEC239D1E81}");
        public static Guid NoteIdForDelete = Guid.Parse("{6FF51ED1-B4DA-40C1-9C35-E63310E8F6C4}");

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    UserId = UserIdA,
                    Id = Guid.Parse("{3B0A8581-1D22-4EC0-A8FD-DEEC239D1E81}"),
                    Name = "Title1",
                    Text = "Text1",
                    CreateDate = DateTime.Today,
                    UpdateDate = null
                },
                new Note
                {
                    UserId = UserIdB,
                    Id = Guid.Parse("{6FF51ED1-B4DA-40C1-9C35-E63310E8F6C4}"),
                    Name = "Title2",
                    Text = "Text2",
                    CreateDate = DateTime.Today,
                    UpdateDate = null
                },
                new Note
                {
                    UserId = UserIdA,
                    Id = Guid.Parse("{C5EB43C4-E570-409C-88F7-14288FEBC3FE}"),
                    Name = "Title3",
                    Text = "Text3",
                    CreateDate = DateTime.Today,
                    UpdateDate = null
                },
                new Note
                {
                    UserId = UserIdB,
                    Id = Guid.Parse("{46D454CE-1F3F-4FC2-A280-CFE5F02AEC3B}"),
                    Name = "Title4",
                    Text = "Text4",
                    CreateDate = DateTime.Today,
                    UpdateDate = null
                }
                );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
