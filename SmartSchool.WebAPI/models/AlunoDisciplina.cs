using System;

namespace SmartSchool.WebAPI.models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        { }
        public AlunoDisciplina(int alunoId, int disciplinaId, int nota)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
            this.Nota = nota;

        }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public int? Nota { get; set; } = null;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}