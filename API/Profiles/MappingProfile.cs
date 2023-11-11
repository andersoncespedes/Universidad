
using API.Dtos;
using AutoMapper;
using AutoMapper.Configuration;
using Domain.Entities;
namespace API.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<CursoEscolar, CursoEscolarDto>().ReverseMap();
        CreateMap<CursoEscolar, CursoWithCountAlumn>()
        .ForMember(e => e.AnyoEscolar, opt => opt.MapFrom(e => e.AnyoFin))
        .ForMember(e => e.CountEstudiantes, opt => opt.MapFrom(e => e.Personas.Count()))
        .ReverseMap();

        CreateMap<Profesor, ProfesiorWithCountAssingnDto>()
        .ForMember(e => e.Asignaturas, opt => opt.MapFrom(e => e.Asignaturas.Count()))
        .ReverseMap();

        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Grado, GradoWithCountDto>()
        .ForMember(e => e.Count, opt => opt.MapFrom(e => e.Asignaturas.Count()))
        .ReverseMap();
        CreateMap<Grado, GradoDto>().ReverseMap();
        CreateMap<Profesor,ProfesorDto>().ReverseMap();
        CreateMap<Persona,PersonaDto>().ReverseMap();
        CreateMap<Asignatura, AsignaturaDto>()
        .ForMember(e => e.Profesor, opt => opt.MapFrom(e => e.Profesor.ProfesorP.Nombre))
        .ReverseMap();
        CreateMap<Departamento, CountByDepDto>()
        .ForMember(e => e.Count, opt => opt.MapFrom(e => e.Profesores.Count()))
        .ReverseMap();
        CreateMap<Profesor, ProfesoresWithDptDto>()
        .ForMember(e => e.Nombre, opt => opt.MapFrom(e => e.ProfesorP.Nombre))
        .ForMember(e => e.Apellido1, opt => opt.MapFrom(e => e.ProfesorP.Apellido1))
        .ForMember(e => e.Apellido2, opt => opt.MapFrom(e => e.ProfesorP.Apellido2))
        .ForMember(e => e.Departamento, opt => opt.MapFrom(e => e.Departamento.Nombre))
        .ReverseMap();
        CreateMap<Departamento, DepartamentWithAsignWithNoCourseDto>()
        .ForMember(e => e.AsignaturasSinCurso, opt => opt.MapFrom(e => e.Profesores.SelectMany(e => e.Asignaturas)))
        .ReverseMap();
        CreateMap<Persona, AsignaturaByStudentDto>()
        .ReverseMap();

        CreateMap<Grado, GradoWithSumDto>()
        .ForMember(e => e.NombreGrado, opt => opt.MapFrom(e => e.Nombre))
        .ForMember(e => e.TipoAsignatura, opt => opt.MapFrom(e => e.Asignaturas.Select(e => e.Creditos).Sum()))
        .ForMember(e => e.TipoAsignatura, opt => opt.MapFrom(e => e.Asignaturas.Select(e => e.Tipos)))
        .ReverseMap();
    }
}
