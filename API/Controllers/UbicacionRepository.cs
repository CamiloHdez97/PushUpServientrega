using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using API.Dtos;
using API.Helpers;
using Domain.Entities;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
 public class UbicacionController : BaseApiController
{

     private readonly IUnitOfWork _unitofwork;
     private readonly IMapper _mapper;

    public UbicacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitofwork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UbicacionDto>>> Get()
    {
        var Con = await  _unitofwork.Ubicaciones.GetAllAsync();
        return _mapper.Map<List<UbicacionDto>>(Con);
    }



    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<UbicacionDto>>> Get11([FromQuery] Params Pparams)
    {
        var pag = await _unitofwork.Ubicaciones.GetAllAsync(Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
        var lstN = _mapper.Map<List<UbicacionDto>>(pag.registros);
        return new Pager<UbicacionDto>(lstN, pag.totalRegistros, Pparams.PageIndex, Pparams.PageSize, Pparams.Search);
    }

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> Get(int id)
    {
        var byidC = await  _unitofwork.Ubicaciones.GetByIdAsync(id);
        return Ok(byidC);
    }

     [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ubicacion>> Post(UbicacionDto ubicacionDto){
        var ubicacion = _mapper.Map<Ubicacion>(ubicacionDto);
        this._unitofwork.Ubicaciones.Add(ubicacion);
        await _unitofwork.SaveAsync();
        if(ubicacion == null)
        {
            return BadRequest();
        }
        ubicacionDto.Id = ubicacion.Id.ToString();
        return CreatedAtAction(nameof(Post),new {id= ubicacionDto.Id}, ubicacionDto);
    }

     [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ubicacion>> Put(int id, [FromBody]Ubicacion ubicacion){
        if(ubicacion == null)
            return NotFound();
        _unitofwork.Ubicaciones.Update(ubicacion);
        await _unitofwork.SaveAsync();
        return ubicacion;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var D = await _unitofwork.Ubicaciones.GetByIdAsync(id);
        if(D == null){
            return NotFound();
        }
        _unitofwork.Ubicaciones.Remove(D);
        await _unitofwork.SaveAsync();
        return NoContent();
    }


   
}