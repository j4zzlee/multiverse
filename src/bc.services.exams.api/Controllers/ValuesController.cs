using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bc.cores.repositories.Models.Exams;
using bc.cores.repositories.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bc.services.exams.api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly ExamRepository _examRepository;
        public ValuesController(ILogger<ValuesController> logger, ExamRepository examRepository)
        {
            _logger = logger;
            _examRepository = examRepository;
        }
        // GET api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<Exam> Get()
        {
            _logger.LogInformation("This is a Get() function");
            return _examRepository.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
