using Notes.Backend.Persistence;

namespace Notes.Backend.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly NotesDbContext _context;

        public TestCommandBase()
        {
            _context = NotesContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(_context);
        }
    }
}
