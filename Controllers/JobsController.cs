using JobBoardWebApi.DTOs.Jobs;
using JobBoardWebApi.Interfaces;
using JobBoardWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        public JobsController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobsById(int id)
        {
            if (id == null || id == 0) return BadRequest();
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();

            if (jobs.Count() == 0) return NotFound("no jobs available");
            return Ok(jobs);
        }

        [HttpPost("create-job")]
       // [Authorize]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto jobDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var job = new Job
            {
                Title = jobDto.Title,
                Description = jobDto.Description,
                Location = jobDto.Location,
                Company = jobDto.Company,
                IsRemote = jobDto.IsRemote,
            };
            
            await _jobRepository.AddJobAsync(job);
            return CreatedAtAction(nameof(GetJobsById), new {id = job.JobId}, job);
            
        }

        // PUT: api/jobs/{id}
        [HttpPut("update/{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobCreateDto jobDto)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingJob = await _jobRepository.GetJobByIdAsync(id);
            if (existingJob == null) return NotFound();

            existingJob.Title = jobDto.Title;
            existingJob.Description = jobDto.Description;
            existingJob.Location = jobDto.Location;
            existingJob.IsRemote = jobDto.IsRemote;

            await _jobRepository.UpdateJobAsync(existingJob);
            return Ok();
        }

        // DELETE: api/jobs/{id}
        [HttpDelete("delete/{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteJob(int id)
        {
            if (id == null || id == 0) return BadRequest();
            var job = await _jobRepository.GetJobByIdAsync(id);
            if (job == null) return NotFound();

            await _jobRepository.DeleteJobAsync(job);
            return Ok();
        }

    }
}
