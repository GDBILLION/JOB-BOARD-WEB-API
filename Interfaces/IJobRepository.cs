using JobBoardWebApi.Models;

namespace JobBoardWebApi.Interfaces
{
    public interface IJobRepository
    {
        Task<Job> GetJobByIdAsync(int id);
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task AddJobAsync (Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(Job job);
    }
}
