using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Test2.DTOs;
using Test2.Hubs;
using Test2.Interfaces;
using Test2.Models;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IHubContext<RecruiterHub> _recruiterHub;
        private readonly IRecruiter _recruiterRepository;
        private readonly ILogger<RecruiterController> _logger;

        public RecruiterController(IRecruiter recruiterRepository, ILogger<RecruiterController> logger, IHubContext<RecruiterHub> hub)
        {
            _recruiterHub = hub;
            _recruiterRepository = recruiterRepository;
            _logger = logger;
        }

        // GET: api/Recruiter
        [HttpGet]
        public IActionResult Get()
        {
            var recruiters = _recruiterRepository.GetAll();
            var results = Mapper.Map<IEnumerable<GetRecruiterDTO>>(recruiters);
            return Ok(results);
        }

        // GET: api/Recruiter/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Recruiter
        [HttpPost]
        public async void PostAsync([FromBody] PostRecruiterDTO postRecruiterDTO)
        {
            var recruiter = Mapper.Map<Recruiter>(postRecruiterDTO);
            //Recruiter _recruiter = new Recruiter();
            //_recruiter.Name = postRecruiterDTO.name;
            _recruiterRepository.Create(recruiter);
            await _recruiterHub.Clients.All.SendAsync("Add", recruiter.Name);
            NoContent();
        }

        // PUT: api/Recruiter/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }




    }
}
