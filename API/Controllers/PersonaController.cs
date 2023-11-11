using System.Net;
using Domain.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Entities;
namespace API.Controllers;
public class PersonaController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _map;
    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _map = mapper;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Personas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<PersonaDto>(dato);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PersonaDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Grados.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<PersonaDto>>(labs.registros);
        return new Pager<PersonaDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> GuardarCurso(PersonaDto param)
    {
        var dato = _map.Map<Persona>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Personas.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Personas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Personas.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _map.Map<PersonaDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Actualizar(PersonaDto param)
    {
        var dato = await _unitOfWork.Personas.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Personas.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpGet("ListaOrd")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<PersonaDto>>  ListSort()
    {
        var dato = _unitOfWork.Personas.AllSort();
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<List<PersonaDto>>(dato);
    }
    [HttpGet("AllButNull")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<PersonaDto>> AllButNull()
    {
        var dato = _unitOfWork.Personas.AllButNotNull();
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<List<PersonaDto>>(dato);
    }
    [HttpGet("GetByBirth")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<PersonaDto>> GetByBirth()
    {
        var dato = _unitOfWork.Personas.GetBeforeTwoThounsend();
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<List<PersonaDto>>(dato);
    }
    [HttpGet("AllButNullWithK")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<PersonaDto>> AllButNullWithK()
    {
        var dato = _unitOfWork.Personas.AllButNotNullWithK();
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<List<PersonaDto>>(dato);
    }
    [HttpGet("GetByNif")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaByStudentDto>>> GetByNif()
    {
        var datos = await _unitOfWork.Personas.GetByNif();
        return _map.Map<List<AsignaturaByStudentDto>>(datos);
    }
    [HttpGet("GetCountByGirlStudent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ToTalStudentsDto>> GetWithCount()
    {
        var datos = await _unitOfWork.Personas.GetCountGirlStudents();
        return Ok(new ToTalStudentsDto
        {Count = datos});
    }
    [HttpGet("GetCount1999")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ToTalStudentsDto>> GetCountMillenials()
    {
        var datos = await _unitOfWork.Personas.GetCountMillen();
        return Ok(new ToTalStudentsDto
        {Count = datos});
    }
    [HttpGet("GetYoungestStudent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> GetYoungestStuden()
    {
        var datos = await _unitOfWork.Personas.GetYoungest();
        return _map.Map<PersonaDto>(datos);
    }

}
