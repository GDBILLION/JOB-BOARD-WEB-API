namespace JobBoardWebApi.DTOs.Jobs
{//accepts data for creating and updating jobs
    public class JobCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public bool IsRemote { get; set; }
    }
}
