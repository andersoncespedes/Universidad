using System.Net;
using Domain.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Entities;
namespace API.Controllers;
public class GradoController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _map;
    public GradoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _map = mapper;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Grados.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _map.Map<GradoDto>(dato);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<GradoDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Grados.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _map.Map<List<GradoDto>>(labs.registros);
        return new Pager<GradoDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> GuardarCurso(GradoDto param)
    {
        var dato = _map.Map<Grado>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Grados.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Grados.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Grados.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _map.Map<GradoDto>(dato);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> Actualizar(GradoDto param)
    {
        var dato = await _unitOfWork.Grados.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Grados.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }
    
}
