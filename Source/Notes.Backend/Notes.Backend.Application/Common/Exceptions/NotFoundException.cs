namespace Notes.Backend.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Called if the desired object was not found in the database
        /// </summary>
        /// <param name="message">Error message that is visible when an exception is thrown</param>
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception innerException) : base(message) { }
    }
}
