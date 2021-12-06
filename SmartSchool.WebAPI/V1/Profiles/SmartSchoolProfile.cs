using AutoMapper;
using SmartSchool.WebAPI.V1.DTOs;
using SmartSchool.WebAPI.models;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V1.Profiles
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