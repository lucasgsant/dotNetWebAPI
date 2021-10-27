using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;

        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _repository.GetAlunos(true);
            return Ok(response);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int Id)
        {
            var response = _repository.GetAlunosById(false, Id);
            if (response == null) return BadRequest("O aluno não foi encontrado");


            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repository.Add(aluno);
            if(_repository.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var response = _repository.GetAlunosById(false, id);
            if (response == null) return BadRequest("O aluno não foi encontrado");


            _repository.Update(aluno);
            if(_repository.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não atualizado");

        }

        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id)
        {
            var response = _repository.GetAlunosById(false, id);
            if (response == null) return BadRequest("O aluno não foi encontrado");

            Aluno aluno = response;

            _repository.Delete(aluno);
            if(_repository.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não deletado");
        }
    }
}