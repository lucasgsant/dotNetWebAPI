using System;

namespace SmartSchool.WebAPI.models
{
    public class AlunoCurso
    {
        public AlunoCurso()
        { }
        public AlunoCurso(int alunoId, Aluno aluno, int CursoId)
        {
            this.AlunoId = alunoId;
            this.CursoId = CursoId;
        }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}