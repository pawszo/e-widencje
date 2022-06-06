using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_widencje.Models;
using e_widencje.Repositories;

namespace e_widencje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExciseEvidencesController : ControllerBase
    {
        private readonly IRepository<ExciseEvidence> _repository;

        public ExciseEvidencesController(IRepository<ExciseEvidence> repository)
        {
            _repository = repository;
        }

        // GET: api/ExciseEvidences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExciseEvidence>>> GetExciseEvidences()
        {
            var evidences = await _repository.GetAll();

            if (evidences == null)
                return NotFound();

            return Ok(evidences);
        }

        // GET: api/ExciseEvidences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExciseEvidence>> GetExciseEvidence(int id)
        {
            var exciseEvidence = await _repository.Get(id);

            if (exciseEvidence == null)
            {
                return NotFound();
            }

            return Ok(exciseEvidence);
        }

        // PUT: api/ExciseEvidences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ExciseEvidence>> PutExciseEvidence(int id, ExciseEvidence exciseEvidence)
        {
            if (id != exciseEvidence.Id)
            {
                return BadRequest();
            }

            var updatedEvidence = await _repository.Update(id, exciseEvidence);

            if (updatedEvidence == null)
                return NotFound();

            return Ok(updatedEvidence);
        }

        // POST: api/ExciseEvidences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExciseEvidence>> PostExciseEvidence(ExciseEvidence exciseEvidence)
        {
            var addedEvidence = await _repository.Add(exciseEvidence);
            if (addedEvidence == null)
                return BadRequest();

            return CreatedAtAction("GetExciseEvidence", new { id = addedEvidence.Id }, addedEvidence);
        }
    }
}
