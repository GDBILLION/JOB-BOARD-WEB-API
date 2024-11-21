using JobBoardWebApi.Data;
using JobBoardWebApi.Interfaces;
using JobBoardWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardWebApi.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddJobAsync(Job job)
        {
            await _context.jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(Job job)
        {
            _context.jobs.Remove(job);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.jobs.ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _context.jobs
                 .FirstOrDefaultAsync(j=>j.JobId == id);
        }

        public async Task UpdateJobAsync(Job job)
        {
            _context.jobs.Update(job);
            await _context.SaveChangesAsync();
        }
    }
}
