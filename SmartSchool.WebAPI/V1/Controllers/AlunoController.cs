using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.DTOs;
using SmartSchool.WebAPI.models;
using System.Threading.Tasks;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var alunos = await _repository.GetAlunosAsync(pageParams, true);
            Response.addPaginationHeader(alunos.currentPage, alunos.totalPages, alunos.pageSize, alunos.totalCount);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpGet("byId")]
        public IActionResult GetById(int Id)
        {
            var aluno = _repository.GetAlunosById(false, Id);
            if (aluno == null) return BadRequest("O aluno não foi encontrado");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);
        }

        [HttpPost]
        public IActionResult Post(AlunoDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            _repository.Add(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/{alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoDto alunoDto)
        {
            var response = _repository.GetAlunosById(false, id);
            if (response == null) return BadRequest("O aluno não foi encontrado");

            var aluno = _mapper.Map<Aluno>(alunoDto);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
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
            if (_repository.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não deletado");
        }
    }
}