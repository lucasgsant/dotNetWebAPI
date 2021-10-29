using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.DTOs;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public ProfessorController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repository.GetProfessores(false);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var professor = _repository.GetProfessoresById(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);
            return Ok(professorDto);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var response = _repository.GetProfessoresById(id, false);
            if (response == null) return BadRequest("O professor não foi encontrado");

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var response = _repository.GetProfessoresById(id, false);
            if (response == null) return BadRequest("O professor não foi encontrado");

            Professor professor = response;

            _repository.Delete(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não deletado");
        }

    }
}