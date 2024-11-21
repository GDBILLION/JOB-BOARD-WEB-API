namespace JobBoardWebApi.DTOs
{//updating the job information from create or database
    public class JobUpdatDto
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool IsRemote { get; set; }
    }
}
