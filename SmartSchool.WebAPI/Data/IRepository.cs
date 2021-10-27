using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<Type>(Type Entity) where Type:class;
         void Update<Type>(Type Entity) where Type:class;
         void Delete<Type>(Type Entity) where Type:class;
         bool SaveChanges();

         Aluno[] GetAlunos(bool IsIncludeProfessor);

         Aluno[] GetAlunosByDisciplina(int disciplinaId, bool IsIncludeProfessor);

         Aluno GetAlunosById(bool IsIncludeProfessor, int alunoId);

        Professor[] GetProfessores(bool IsIncludeAlunos);

        Professor[] GetProfessoresByDisciplina(int disciplinaId, bool IsIncludeAlunos);

        Professor GetProfessoresById(int professorId, bool IsIncludeAlunos);


         
    }
}