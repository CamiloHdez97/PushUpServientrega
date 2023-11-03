using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class DireccionController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public DireccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DireccionDto>>> Get()
    {
        var Con = await  _unitofwork.Direcciones.GetAllAsync();
        return _mapper.Map<List<DireccionDto>>(Con);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DireccionDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Direcciones.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<DireccionDto>>(pag.registros);
        return new Pager<DireccionDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Direcciones.GetByIdAsync(id);
        return Ok(byidC);
    }

     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Direccion>> Post(DireccionDto direccionDto){
        var direccion = _mapper.Map<Direccion>(direccionDto);
        this._unitofwork.Direcciones.Add(direccion);
        await _unitofwork.SaveAsync();
        if(direccion == null)
        {
            return BadRequest();
        }
        direccionDto.Id = direccion.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= direccionDto.Id}, direccionDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Direccion>> Put(int id, [FromBody]Direccion direccion){
        if(direccion == null)
            return NotFound();
        _unitofwork.Direcciones.Update(direccion);
        await _unitofwork.SaveAsync();
        return direccion;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Direcciones.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Direcciones.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}