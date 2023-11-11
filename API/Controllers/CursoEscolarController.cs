using System.Net;
using API.Helpers;
using API.Dtos;
using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace API.Controllers;
public class CursoEscolarController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _map;
    public CursoEscolarController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _map = mapper;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> GetById(int id){
        var dato = await _unitOfWork.CursoEscolares.GetById(id);
        if(dato == null){
            return BadRequest();
        }
        return _map.Map<CursoEscolarDto>(dato);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CursoEscolarDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.CursoEscolares.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<CursoEscolarDto>>(labs.registros);
        return new Pager<CursoEscolarDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> GuardarCurso(CursoEscolarDto param){
        var dato = _map.Map<CursoEscolar>(param);
        if(dato == null){
            return BadRequest();
        }
        _unitOfWork.CursoEscolares.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> Borrar(int id){
        var dato = await _unitOfWork.CursoEscolares.GetById(id);
        if(dato == null){
            return BadRequest();
        }
        _unitOfWork.CursoEscolares.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _map.Map<CursoEscolarDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> Actualizar(CursoEscolarDto param){
        var dato = await _unitOfWork.CursoEscolares.GetById(param.Id);
        if(dato == null){
            return BadRequest();
        }
        _unitOfWork.CursoEscolares.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpGet("GetWithStudents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetStudentsDate(){
        var datos = await _unitOfWork.CursoEscolares.GetStudentsDate();
        return _map.Map<List<PersonaDto>>(datos);
    }
}
