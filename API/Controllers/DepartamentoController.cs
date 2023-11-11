using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Entities;
namespace API.Controllers;
public class DepartamentoController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _map;
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _map = mapper;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Departamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<DepartamentoDto>(dato);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DepartamentoDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Departamentos.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<DepartamentoDto>>(labs.registros);
        return new Pager<DepartamentoDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> GuardarCurso(DepartamentoDto param)
    {
        var dato = _map.Map<Departamento>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Departamentos.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Departamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Departamentos.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _map.Map<DepartamentoDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Actualizar(DepartamentoDto param)
    {
        var dato = await _unitOfWork.Departamentos.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Departamentos.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpGet("DepWithProf")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> DepartamentoWithProfesoresThatDoesHaveAsign()
    {
        var dato = await _unitOfWork.Departamentos.GetWithProfWhoDoesHaveAsign();
        return _map.Map<List<DepartamentoDto>>(dato);
    }
    [HttpGet("DepWithNoAssign")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentWithAsignWithNoCourseDto>>> DepWithNoAssign()
    {
        var dato = await _unitOfWork.Departamentos.GetWithAsignWithNoCourse();
        return _map.Map<List<DepartamentWithAsignWithNoCourseDto>>(dato);
    }
    [HttpGet("GetCountByDep")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountByDepDto>>> GetWithCountByDep()
    {
        var dato = await _unitOfWork.Departamentos.GetCountWithProf();
        return _map.Map<List<CountByDepDto>>(dato);
    }
    [HttpGet("GetCountByDepAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<IEnumerable<CountByDepDto>>> GetWithCountByDepAll()
    {
        var dato = await _unitOfWork.Departamentos.ge();
        return _map.Map<List<CountByDepDto>>(dato);
    }
}
