using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.models
{
    public class Aluno
    {
        public Aluno()
        { }
        public Aluno(int id, int matricula, string nome, string sobreNome, string telefone, DateTime dataDeNascimento)
        {
            this.Id = id;
            this.Matricula = Matricula;
            this.Nome = nome;
            this.SobreNome = sobreNome;
            this.Telefone = telefone;
            this.DataDeNascimento = dataDeNascimento;

        }
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}