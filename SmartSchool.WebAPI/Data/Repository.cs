using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public Repository(SmartContext context)
        {
            _context = context;

        }
        public void Add<Type>(Type entity) where Type : class
        {
            _context.Add(entity);
        }

        public void Update<Type>(Type entity) where Type : class
        {
            _context.Update(entity);
        }

        public void Delete<Type>(Type entity) where Type : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() > 0);
        }

        public async Task<PageList<Aluno>> GetAlunosAsync(PageParams pageParams, bool IsIncludeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;
    

            if(IsIncludeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            //Filtros 
            if(!string.IsNullOrEmpty(pageParams.Nome))
                query = query.Where(aluno => aluno.Nome
                                                        .ToUpper()
                                                        .Contains(pageParams.Nome)
                                                        || 
                                                        aluno.SobreNome
                                                        .ToUpper()
                                                        .Contains(pageParams.Nome));
            if(pageParams.Matricula > 0){
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);
            }

            query = query.Where(aluno => aluno.Ativo == pageParams.Ativo);
            //Filtros 
            
            return await PageList<Aluno>.CreateAsync(query, pageParams.pageNumber, pageParams.pageSize);
        }

        public Aluno[] GetAlunosByDisciplina(int disciplinaId, bool IsIncludeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(IsIncludeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                            .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId))
                            .OrderBy(a => a.Id);

            return query.ToArray();  
        }

        public Aluno GetAlunosById(bool IsIncludeProfessor, int alunoId)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(IsIncludeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                            .Where(aluno => aluno.Id == alunoId)
                            .OrderBy(a => a.Id);

            return query.FirstOrDefault();  
        }

        public Professor[] GetProfessores(bool IsIncludeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;

            if(IsIncludeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                                .ThenInclude(d => d.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Aluno);          
            }
            
            query = query.AsNoTracking()
                            .OrderBy(p => p.Id);
            
            return query.ToArray();
        }

        public Professor[] GetProfessoresByDisciplina(int disciplinaId, bool IsIncludeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;

            if(IsIncludeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                                .ThenInclude(d => d.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Aluno);          
            }
            
            query = query.AsNoTracking()
                            .Where(p => p.Disciplinas.Any(d => d.Id == disciplinaId))
                            .OrderBy(p => p.Id);
            
            return query.ToArray();
        }

        public Professor GetProfessoresById(int professorId, bool IsIncludeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;

            if(IsIncludeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                                .ThenInclude(d => d.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Aluno);          
            }
            
            query = query.AsNoTracking()
                            .Where(p => p.Id == professorId)
                            .OrderBy(p => p.Id);
            
            return query.FirstOrDefault();
        }

    }
}