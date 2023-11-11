
using API.Dtos;
using AutoMapper;
using AutoMapper.Configuration;
using Domain.Entities;
namespace API.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<CursoEscolar, CursoEscolarDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Grado, GradoDto>().ReverseMap();
        CreateMap<Profesor,ProfesorDto>().ReverseMap();
        CreateMap<Persona,PersonaDto>().ReverseMap();
        CreateMap<Asignatura, AsignaturaDto>()
        .ForMember(e => e.Profesor, opt => opt.MapFrom(e => e.Profesor.ProfesorP.Nombre))
        .ReverseMap();

        CreateMap<Profesor, ProfesoresWithDptDto>()
        .ForMember(e => e.Nombre, opt => opt.MapFrom(e => e.ProfesorP.Nombre))
        .ForMember(e => e.Apellido1, opt => opt.MapFrom(e => e.ProfesorP.Apellido1))
        .ForMember(e => e.Apellido2, opt => opt.MapFrom(e => e.ProfesorP.Apellido2))
        .ForMember(e => e.Departamento, opt => opt.MapFrom(e => e.Departamento.Nombre))
        .ReverseMap();
        
        CreateMap<Persona, AsignaturaByStudentDto>()
        .ReverseMap();
    }
}
