namespace Notes.Backend.Application.Notes.Queries
{
    public class GetNotesViewModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
