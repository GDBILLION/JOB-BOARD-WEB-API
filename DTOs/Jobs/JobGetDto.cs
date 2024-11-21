namespace JobBoardWebApi.DTOs.Jobs
{
    public class JobGetDto
    {
        //public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public bool IsRemote { get; set; }
    }
}
