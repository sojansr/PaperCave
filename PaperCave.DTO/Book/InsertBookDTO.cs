namespace PaperCave.DTO.Book
{
    public sealed class InsertBookDTO : BookDTO
    {
        public InsertBookDTO() 
        {
            var currentTime = DateTime.Now;
            CreatedTs = currentTime;
            UpdatedTs = currentTime;
        }

        public int AuthorId { get; set; }   
        public DateTime CreatedTs { get; set; }
        public DateTime UpdatedTs { get; set; }
    }
}
