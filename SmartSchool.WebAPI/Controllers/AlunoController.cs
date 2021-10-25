using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                SobreNome = "Almeida",
                Telefone = "1234567"
            },
            new Aluno(){
                Id = 2,
                Nome = "Marta",
                SobreNome = "Kent",
                Telefone = "1234567"
            },
            new Aluno(){
                Id = 3,
                Nome = "Bruno",
                SobreNome = "Barros",
                Telefone = "1234567"
            }
        };
        public AlunoController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == Id);
            if(aluno == null) return BadRequest("O aluno não foi encontrado");


            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }
    }
}