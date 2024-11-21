namespace JobBoardWebApi.DTOs.Application
{
    public class ApplicationDto
    {
        public int JobId { get; set; }
        public string Resume { get; set; }
        public string CoverLetter { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
