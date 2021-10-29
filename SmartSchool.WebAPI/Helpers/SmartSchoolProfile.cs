using AutoMapper;
using SmartSchool.WebAPI.DTOs;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {   
        public SmartSchoolProfile()
        {
            CreateMap<Aluno,AlunoDto>()
                    .ForMember(
                        dest => dest.Nome,
                        opt => opt.MapFrom(src => $"{src.Nome} {src.SobreNome}")
                    )
                    .ForMember(
                        dest => dest.Idade,
                        opt => opt.MapFrom(src => src.DataDeNascimento.GetCurrentAge())
                    );
            CreateMap<AlunoDto, Aluno>();

            CreateMap<AlunoRegistroDto, Aluno>();

            CreateMap<Professor, ProfessorDto>()
                    .ForMember(
                        dest => dest.Nome,
                        opt => opt.MapFrom(src => $"{src.Nome} {src.SobreNome}")
                    );
        } 
    }
}