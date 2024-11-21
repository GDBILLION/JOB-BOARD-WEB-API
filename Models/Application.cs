using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoardWebApi.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; } //reference to the primary key of the user table
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public string Resume { get; set; }
        public string CoverLetter { get; set; }
        public DateTime AppliedDate { get; set; }
        public Job Job { get; set; }
        public User User { get; set; } //navigational property or reference
    }
}